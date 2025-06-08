namespace ECommerce.Infrastructure.Services.Notifications;

public class NotificationSettings
{
    public string SmtpHost { get; set; } = default!;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = default!;
    public string SmtpPass { get; set; } = default!;

    public string TwilioAccountSid { get; set; } = default!;
    public string TwilioAuthToken { get; set; } = default!;
    public string TwilioPhoneNumber { get; set; } = default!;
}
