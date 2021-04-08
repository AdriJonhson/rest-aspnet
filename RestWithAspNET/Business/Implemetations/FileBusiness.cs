using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestWithAspNET.Data.VO;

namespace RestWithAspNET.Business.Implemetations
{
    public class FileBusiness : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusiness(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "/Uploads/";
        }

        public byte[] GetFile(string filename)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetailVo = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg" )
            {
                var docName = Path.GetFileName(file.FileName);

                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetailVo.DocumentName = docName;
                    fileDetailVo.DocumentType = fileType;
                    fileDetailVo.DocumentUrl = Path.Combine(_basePath, "/api/v1/file/", docName);;

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }

            return fileDetailVo;
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();

            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }

            return list;
        }
    }
}