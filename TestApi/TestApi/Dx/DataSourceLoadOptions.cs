using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestApi.Dx
{
    [ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase
    {
    }

    public class DataSourceLoadOptionsBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var loadOptions = new DataSourceLoadOptions();
            DataSourceLoadOptionsParser.Parse(loadOptions, key => { 
                return bindingContext.ValueProvider.GetValue(key).FirstOrDefault(); });
            bindingContext.Result = ModelBindingResult.Success(loadOptions);
            return Task.CompletedTask;
        }
    }


    [ModelBinder(BinderType = typeof(UserContextBinder))]
    public class UserContext
    {
        public int? UserId { get; set; }
        public int? OrgId { get; set; }
        public int? Year { get; set; }
    }

    public class UserContextBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var usrContext = new UserContext();
            var usrId = bindingContext.ValueProvider.GetValue("user_context_user_id").FirstOrDefault();
            if (usrId != null)
                usrContext.UserId = Convert.ToInt16(usrId);

            var orgId = bindingContext.ValueProvider.GetValue("user_context_org_id").FirstOrDefault();
            if (orgId != null)
                usrContext.OrgId = Convert.ToInt16(orgId);

            var year = bindingContext.ValueProvider.GetValue("user_context_year").FirstOrDefault();
            if (year != null)
                usrContext.Year = Convert.ToInt16(year);

            bindingContext.Result = ModelBindingResult.Success(usrContext);
            return Task.CompletedTask;
        }
    }
}
