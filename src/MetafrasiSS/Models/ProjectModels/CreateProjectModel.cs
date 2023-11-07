using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Models.ProjectModels;

public class CreateProjectModel
{
	//public CreateProjectModel(
	//	string name,
	//	string description,
	//	DateTime created,
	//	DateTime updated,
	//	UserId userId,
	//	string fileName,
	//	string fileContent)
	//{
	//	Name = name;
	//	Description = description;
	//	Created = created;
	//	Updated = updated;
	//	UserId = userId;
	//	FileName = fileName;
	//	FileContent = fileContent;
	//}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	[MaxLength(300)]
	public string Name { get; set; }

	[MaxLength(500)]
	public string Description { get; set; }

	public DateTime Created { get; set; }

	public DateTime Updated { get; set; }

	public UserId UserId { get; set; }

	public ProjectFileModel File { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}