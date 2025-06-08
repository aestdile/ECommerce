namespace ECommerce.Domain.Enums;

public enum OrderStatus
{
    Pending = 0,      // Buyurtma yaratilgan, lekin hali qayta ishlanmagan
    Processing = 1,   // Buyurtma qayta ishlanmoqda (tayyorlanmoqda)
    Shipped = 2,      // Buyurtma yetkazib berish uchun jo‘natilgan
    Delivered = 3,    // Buyurtma mijozga yetkazilgan
    Cancelled = 4     // Buyurtma bekor qilingan
}
