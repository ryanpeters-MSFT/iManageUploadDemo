using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [Route("file")]
        [RequestSizeLimit(8000000000)]
        public object UploadFile()
        {
            var text = Request.Form["Text"].ToString();

            return new
            {
                text,
                files = Request.Form.Files.Count,
                size = Request.Form.Files[0].Length
            };
        }
    }
}