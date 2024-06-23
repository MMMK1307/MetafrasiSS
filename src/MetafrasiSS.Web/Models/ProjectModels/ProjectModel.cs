using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.ProjectModels;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

public class ProjectModel
{
    public ProjectId Id { get; set; }

    [MaxLength(500)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public UserId UserId { get; set; }

    public List<ProjectFileModel> Files { get; set; }
}