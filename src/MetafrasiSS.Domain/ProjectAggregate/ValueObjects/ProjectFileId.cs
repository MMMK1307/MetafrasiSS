﻿using MetafrasiSS.Domain.Common.Models;

namespace MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

public class ProjectFileId : ValueObject
{
    private ProjectFileId(Guid value)
    {
        Value = value;
    }

    private ProjectFileId()
    {
    }

    public Guid Value { get; protected set; }

    public static ProjectFileId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProjectFileId Create(Guid value)
    {
        return new ProjectFileId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}