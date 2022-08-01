using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using TestApi.Db;

namespace TestApi.Dx
{

    [Route("dx")]
    public class DocumentsController : Controller
    {
        private readonly Context _dbContext;

        public DocumentsController(Context dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("Documents")]
        public async Task<IActionResult> Get(UserContext userContext, DataSourceLoadOptions? loadOptions)
        {
            var source = _dbContext.Documents;

            return Json(await DataSourceLoader.LoadAsync(source, loadOptions));
        }
    }
}
