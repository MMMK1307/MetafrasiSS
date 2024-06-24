using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Web.Models.ProjectModels;

public class ProjectFileModel
{
    public ProjectFileModel(
        ProjectFileId id,
        string name,
        string content,
        DateTime created,
        DateTime updated)
    {
        Id = id;
        Name = name;
        Content = content;
        Created = created;
        Updated = updated;
    }

    public ProjectFileModel(ProjectFileId id, string name, string content)
    {
        Id = id;
        Name = name;
        Content = content;
    }

    public ProjectFileId Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public static ProjectFileModel Create(string name, string content)
    {
        return new ProjectFileModel(ProjectFileId.CreateUnique(), name: name, content: content);
    }
}