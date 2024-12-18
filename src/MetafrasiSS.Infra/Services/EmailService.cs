using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Infra.Common.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using MetafrasiSS.Domain.Services;

namespace MetafrasiSS.Infra.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> settings)
    {
        _smtpSettings = settings.Value;
    }

    public async Task<bool> SendEmail(EmailServiceData emailData)
    {
        try
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(_smtpSettings.Username, _smtpSettings.Name),
                Subject = emailData.Subject,
                Body = emailData.Body,
                IsBodyHtml = true,
                Priority = MailPriority.High,
            };

            mail.To.Add(emailData.Email);

            using (var smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Door))
            {
                smtp.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Pass);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
                return true;
            }
        }
        catch (SmtpException)
        {
            return false;
        }
    }
}