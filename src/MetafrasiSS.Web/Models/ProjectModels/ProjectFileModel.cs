using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Web.Models.ProjectModels;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

public class ProjectFileModel
{
	public ProjectFileId Id { get; set; }

	public string Name { get; set; }

	public string Content { get; set; }

	public DateTime Created { get; set; }

	public DateTime Updated { get; set; }
}