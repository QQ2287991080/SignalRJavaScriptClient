using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace SignalRForJavaScript.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : Controller
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public JsonResult Get()
        {
            #region 测试 

            #endregion
            return new JsonResult("测试");
        }

    }
}