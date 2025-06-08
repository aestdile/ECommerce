using System.Net;
using System.Net.Mail;
using ECommerce.Application.Abstractions.Services;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ECommerce.Infrastructure.Services.Notifications;

public class NotificationService : INotificationService
{
    private readonly NotificationSettings _settings;

    public NotificationService(IOptions<NotificationSettings> options)
    {
        _settings = options.Value;

        TwilioClient.Init(_settings.TwilioAccountSid, _settings.TwilioAuthToken);
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using var client = new SmtpClient(_settings.SmtpHost, _settings.SmtpPort)
        {
            Credentials = new NetworkCredential(_settings.SmtpUser, _settings.SmtpPass),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_settings.SmtpUser),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(toEmail);

        await client.SendMailAsync(mailMessage);
    }

    public async Task SendSmsAsync(string toPhoneNumber, string message)
    {
        var messageResult = await MessageResource.CreateAsync(
            to: new PhoneNumber(toPhoneNumber),
            from: new PhoneNumber(_settings.TwilioPhoneNumber),
            body: message
        );
    }
}
