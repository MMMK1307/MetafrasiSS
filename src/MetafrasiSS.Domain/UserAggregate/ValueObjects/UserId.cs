using MetafrasiSS.Domain.Common.Models;

namespace MetafrasiSS.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value)
    {
        Value = value;
    }

    private UserId()
    {
    }

    public override Guid Value { get; protected set; }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}