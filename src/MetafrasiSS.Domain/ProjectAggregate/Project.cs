using MetafrasiSS.Domain.Common.Models;
using MetafrasiSS.Domain.ProjectAggregate.Entities;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Domain.ProjectAggregate;

public class Project : AggregateRoot<ProjectId, Guid>
{
    public Guid _userId;

    private readonly List<ProjectFile> _files = new();

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

    public DateTime Created { get; }
    public string Description { get; } = null!;
    public IReadOnlyList<ProjectFile> Files => _files.AsReadOnly();
    public string Name { get; } = null!;
    public DateTime Updated { get; }
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