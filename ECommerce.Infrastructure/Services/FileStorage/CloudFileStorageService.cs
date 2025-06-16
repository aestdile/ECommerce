using Amazon.S3;
using Amazon.S3.Model;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Abstractions.Services.FileStorage;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infrastructure.Services.FileStorage
{
    public class CloudFileStorageService : IFileStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public CloudFileStorageService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"]
                ?? throw new ArgumentNullException("AWS:BucketName konfiguratsiyada yo‘q");
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = fileStream,
                ContentType = contentType,
                AutoCloseStream = true
            };

            var response = await _s3Client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
            }

            throw new Exception("Faylni yuklashda xatolik yuz berdi");
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            var response = await _s3Client.DeleteObjectAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<Stream?> GetFileAsync(string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            try
            {
                var response = await _s3Client.GetObjectAsync(request);
                return response.ResponseStream;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
