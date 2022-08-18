using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        [RequestSizeLimit(8000000000)]
        public async Task<object> UploadFile()
        {
            var filePath = @$"C:\Users\Administrator\Desktop\{Guid.NewGuid()}.dat";

            using (var file = System.IO.File.OpenWrite(filePath))
            {
                await Request.Body.CopyToAsync(file);
            }

            return true;
        }
    }
}