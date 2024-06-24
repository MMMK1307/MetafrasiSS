using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.ProjectModels;

public class CreateProjectModel
{
    public CreateProjectModel(
       string name,
       string description,
       DateTime created,
       DateTime updated,
       UserId userId,
       string fileName,
       string fileContent)
    {
        Name = name;
        Description = description;
        Created = created;
        Updated = updated;
        UserId = userId;
        File = ProjectFileModel.Create(name: fileName, content: fileContent);
    }

    [MaxLength(300)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public UserId UserId { get; set; }

    public ProjectFileModel File { get; set; }
}