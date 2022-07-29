using TestApi.Db;
using TestApi.Domain;

namespace TestApi.GraphQl
{
    public class Query
    {
        //private readonly Context _dbContext;
        //public Query(Context dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Document> Documents([Service] Context dbContext) => dbContext.Documents;

    }
}
