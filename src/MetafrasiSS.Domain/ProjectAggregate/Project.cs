using MetafrasiSS.Domain.Common.Models;
using MetafrasiSS.Domain.ProjectAggregate.Entities;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Domain.ProjectAggregate;

public class Project : AggregateRoot<ProjectId, Guid>
{
    public Project(
        ProjectId id,
        string name,
        string description,
        List<ProjectFile> files,
        DateTime created,
        DateTime updated,
        UserId userId)
        : base(id)
    {
        Name = name;
        Description = description;
        _files = files;
        Created = created;
        Updated = updated;
        UserId = userId;
    }

    protected Project()
    {
    }

    public string Name { get; } = null!;

    public string Description { get; } = null!;

    public DateTime Created { get; }

    public DateTime Updated { get; }

    private readonly List<ProjectFile> _files = new();

    public IReadOnlyList<ProjectFile> Files => _files.AsReadOnly();

    public Guid _userId;

    public UserId UserId { get => UserId.Create(_userId); set => _userId = value.Value; }

    public static Project Create(
        string name,
        string description,
        List<ProjectFile> files,
        DateTime created,
        DateTime updated,
        UserId userId)
    {
        return new Project(
            ProjectId.CreateUnique(),
            name,
            description,
            files,
            created,
            updated,
            userId);
    }
}