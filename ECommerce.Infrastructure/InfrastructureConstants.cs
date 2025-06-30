namespace ECommerce.Infrastructure
{
    public static class InfrastructureConstants
    {
        public const string LocalUploadFolder = "wwwroot/uploads";
        public const string ProductImagesFolder = "product-images";
        public const string UserProfileImagesFolder = "user-profiles";

        public static class AwsS3
        {
            public const string BucketName = "your-s3-bucket-name"; 
            public const string Region = "us-east-1"; 
            public const string FolderPrefix = "ecommerce"; 
        }

        public const int MaxImageFileSizeInMB = 5;     
        public const int MaxDocumentFileSizeInMB = 10;  

        public static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        public const string SupportEmail = "support@yourdomain.com";

        public const string DefaultCurrency = "USD";

        public static class Messages
        {
            public const string FileUploadSuccess = "Fayl muvaffaqiyatli yuklandi.";
            public const string FileUploadError = "Fayl yuklashda xatolik yuz berdi.";
            public const string PaymentFailed = "To‘lov amalga oshmadi.";
            public const string PaymentSuccess = "To‘lov muvaffaqiyatli amalga oshirildi.";
        }
    }
}
