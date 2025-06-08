namespace ECommerce.Domain.Enums;

public enum PaymentStatus
{
    Pending = 0,    // To‘lov hali amalga oshirilmagan
    Paid = 1,       // To‘lov muvaffaqiyatli amalga oshirilgan
    Failed = 2,     // To‘lovda xatolik yuz bergan
    Refunded = 3    // To‘lov qaytarilgan
}
