using MetafrasiSS.Domain.Common.Models;

namespace MetafrasiSS.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
	public override Guid Value { get; protected set; }

	private UserId(Guid value)
	{
		Value = value;
	}

	public static UserId CreateUnique()
	{
		return new(Guid.NewGuid());
	}

	public static UserId Create(Guid value)
	{
		return new UserId(value);
	}

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

	private UserId()
	{
	}
}