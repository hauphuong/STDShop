using STDShop.Service;
using STDShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace STDShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, STD Member.";
        }
    }
}