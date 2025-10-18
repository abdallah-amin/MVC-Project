using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services;
public interface IDocumentService
{
    Task<string> UploadAsync(IFormFile filePath, string folderName);
    bool Delete(string filePath, string folderName);
}
