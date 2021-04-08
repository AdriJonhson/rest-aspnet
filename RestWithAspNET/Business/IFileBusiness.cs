using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestWithAspNET.Data.VO;

namespace RestWithAspNET.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public List<FileDetailVO> SaveFilesToDisk(IList<IFormFile> files);
    }
}