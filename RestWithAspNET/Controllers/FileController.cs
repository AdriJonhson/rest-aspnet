using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Business;
using RestWithAspNET.Data.VO;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        [HttpPost("uploadFile")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _fileBusiness.SaveFileToDisk(file);

            return new ObjectResult(detail);
        }
        
        [HttpPost("uploadManyFiles")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UploadManyFile([FromForm] List<IFormFile> files)
        {
            List<FileDetailVO> details = await _fileBusiness.SaveFilesToDisk(files);

            return new ObjectResult(details);
        }
    }
}