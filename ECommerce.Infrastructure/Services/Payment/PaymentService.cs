using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Application.Abstractions.Services.NotificationService;
using ECommerce.Application.Abstractions.Services.Payment;
using ECommerce.Domain.Enums;

namespace ECommerce.Infrastructure.Services.Payment;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentGatewayService _paymentGatewayService;
    private readonly INotificationService _notificationService;

    public PaymentService(
        IPaymentRepository paymentRepository,
        IOrderRepository orderRepository,
        IPaymentGatewayService paymentGatewayService,
        INotificationService notificationService)
    {
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
        _paymentGatewayService = paymentGatewayService;
        _notificationService = notificationService;
    }


    public async Task<Domain.Entities.Payment.Payment> CreatePaymentAsync(Guid orderId, decimal amount, Guid paymentMethodId, string? createdBy = null)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new Exception($"{orderId} bu id bo'yicha order topilmadi");

        var payment = new Domain.Entities.Payment.Payment
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Amount = amount,
            PaymentMethodId = paymentMethodId,
            Status = PaymentStatus.Pending,
            CreatedBy = createdBy,
            CreatedOn = DateTime.UtcNow
        };

        return await _paymentRepository.AddAsync(payment);
    }

    public async Task<bool> ProcessPaymentAsync(Guid paymentId)
    {
        var payment = await _paymentRepository.GetByIdAsync(paymentId);
        if (payment == null)
            throw new Exception($"{paymentId} bu id bo'yicha payment topilmadi");

        var isSuccess = await _paymentGatewayService.ProcessPaymentAsync(paymentId);

        payment.Status = isSuccess ? PaymentStatus.Paid : PaymentStatus.Failed;
        payment.ModifiedOn = DateTime.UtcNow;

        await _paymentRepository.UpdateAsync(payment);

        var order = await _orderRepository.GetByIdAsync(payment.OrderId);
        if (order?.User != null)
        {
            var email = order.User.Email;
            var phone = order.User.PhoneNumber;
            var message = isSuccess
                ? $"To‘lov muvaffaqiyatli amalga oshirildi. Buyurtma raqami: {order.Id}"
                : $"To‘lov amalga oshmadi. Iltimos, qaytadan urinib ko‘ring. Buyurtma: {order.Id}";

            if (!string.IsNullOrWhiteSpace(email))
            {
                await _notificationService.SendEmailAsync(email, "To‘lov holati", message);
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                await _notificationService.SendSmsAsync(phone, message);
            }
        }

        return isSuccess;
    }

    public async Task<List<Domain.Entities.Payment.Payment>> GetPaymentHistoryByUserIdAsync(Guid userId)
    {
        return await _paymentRepository.GetPaymentsByUserIdAsync(userId);
    }

    public async Task UpdatePaymentStatusAsync(Guid paymentId, PaymentStatus status, string? modifiedBy = null)
    {
        var payment = await _paymentRepository.GetByIdAsync(paymentId);
        if (payment == null)
            throw new Exception($"Payment with ID {paymentId} not found");

        payment.Status = status;
        payment.ModifiedBy = modifiedBy;
        payment.ModifiedOn = DateTime.UtcNow;

        await _paymentRepository.UpdateAsync(payment);
    }
}
