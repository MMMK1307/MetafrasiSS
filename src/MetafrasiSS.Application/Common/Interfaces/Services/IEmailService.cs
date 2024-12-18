using MetafrasiSS.Domain.Services;

namespace MetafrasiSS.Application.Common.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmail(EmailServiceData emailData);
}