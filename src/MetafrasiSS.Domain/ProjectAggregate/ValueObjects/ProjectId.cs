using MetafrasiSS.Domain.Common.Models;

namespace MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

public class ProjectId : AggregateRootId<Guid>
{
	public override Guid Value { get; protected set; }

	private ProjectId(Guid value)
	{
		Value = value;
	}

	public static ProjectId CreateUnique()
	{
		return new(Guid.NewGuid());
	}

	public static ProjectId Create(Guid value)
	{
		return new ProjectId(value);
	}

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

	private ProjectId()
	{
	}
}