
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services;
public class DocumentService : IDocumentService
{
    private List<string> _allowedExtentions = [".png", ".jpg"];
    private const int _MAXSIZE = 2_097_152;

    public async Task<string> UploadAsync(IFormFile file, string folderName)
    {
        var extention = Path.GetExtension(file.FileName);
        if (!_allowedExtentions.Contains(extention))
            return null!;
        if (file.Length > _MAXSIZE)
            return null!;
        var fileName = $"{Guid.NewGuid()}{extention}";
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", folderName);
        var filePath = Path.Combine(folderPath, fileName);
        using Stream fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        return fileName;
    }
    public bool Delete(string fileName, string folderName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", folderName, fileName);
        if (!File.Exists(filePath))
            return false;
        File.Delete(filePath);
        return true;
    }

}
