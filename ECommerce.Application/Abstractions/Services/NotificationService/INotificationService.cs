namespace ECommerce.Application.Abstractions.Services.NotificationService;

public interface INotificationService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
    Task SendSmsAsync(string toPhoneNumber, string message);
}
