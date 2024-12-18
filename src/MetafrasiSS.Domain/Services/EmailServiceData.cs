namespace MetafrasiSS.Domain.Services;

public class EmailServiceData
{
    private EmailServiceData(string subject, string body, string email)
    {
        Subject = subject;
        Body = body;
        Email = email;
    }

    public string Subject { get; }
    public string Body { get; }
    public string Email { get; }

    public static EmailServiceData Create(string subject, string body, string email)
    {
        return new EmailServiceData(subject, body, email);
    }
}
