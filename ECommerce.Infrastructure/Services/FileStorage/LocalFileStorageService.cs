using ECommerce.Application.Abstractions.Services;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Services.FileStorage
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _basePath;

        public LocalFileStorageService()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            var filePath = Path.Combine(_basePath, fileName);

            using (var fileStreamOut = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fileStreamOut);
            }

            return filePath;
        }

        public Task<bool> DeleteFileAsync(string fileUrl)
        {
            if (File.Exists(fileUrl))
            {
                File.Delete(fileUrl);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
