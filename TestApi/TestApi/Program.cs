
using Microsoft.EntityFrameworkCore;
using TestApi.Db;
using TestApi.GraphQl;

using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(opt => opt
        .UseNpgsql($"Host=localhost;Port=5440;Database=postgres;Username=postgres;Password=123456")
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging(true)
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        ); 
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddControllers().AddOData(opt => 
    opt.AddRouteComponents("odata", GetEdmModel())
            .Select()
            .Filter()
            .OrderBy()
            .Count()
            .Expand()
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    //logging.RequestBodyLogLimit = 4096;
    //logging.ResponseBodyLogLimit = 1;
});


var app = builder.Build();

app.UseHttpLogging();

app.Use(async (context, next) =>
{
    // Do loging
    // Do work that doesn't write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use odata route debug, /$odata
app.UseODataRouteDebug();
// Add OData /$query middleware
app.UseODataQueryRequest();
// Add the OData Batch middleware to support OData $Batch
app.UseODataBatching();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(b => { 
    b.AllowAnyHeader();
    //b.AllowAnyMethod();
    //b.AllowCredentials();
    b.AllowAnyOrigin();
});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapODataRoute("odata", "odata", GetEdmModel());
//});


app.UseAuthorization();

app.MapGraphQL("/graphql");

app.MapControllers();

app.Run();


IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<TestApi.Domain.Document>("Documents");
    return builder.GetEdmModel();
}