using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using TestApi.Db;

namespace TestApi.OData
{
    public class OdDocumentsController : Controller
    {
        private readonly Context _dbContext;

        public OdDocumentsController(Context dbContext) 
        {
            this._dbContext = dbContext;
        }
        
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Documents);
        }

        [EnableQuery]
        public IActionResult Get(long key)
        {
            return Ok(_dbContext.Documents.Where(x => x.Id == key));
        }
    }
}
