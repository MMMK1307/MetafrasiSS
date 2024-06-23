using MetafrasiSS.Domain.Common.Models;

namespace MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

public class ProjectId : AggregateRootId<Guid>
{
    private ProjectId(Guid value)
    {
        Value = value;
    }

    private ProjectId()
    {
    }

    public override Guid Value { get; protected set; }

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
}