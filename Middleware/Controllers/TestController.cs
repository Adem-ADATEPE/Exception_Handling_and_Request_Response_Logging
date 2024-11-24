using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]

        public string Get()
        {
            int a = 0;
            int b = 13/a;

            return "ok";
        }
    }
}
