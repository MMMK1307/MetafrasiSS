using MetafrasiSS.Application.Common.Interfaces.Services;

namespace MetafrasiSS.Infra.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}