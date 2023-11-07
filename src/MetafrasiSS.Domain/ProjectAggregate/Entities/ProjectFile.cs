using MetafrasiSS.Domain.Common.Models;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Domain.ProjectAggregate.Entities;

public class ProjectFile : Entity<ProjectFileId>
{
	public ProjectFile(
		ProjectFileId id, 
		string name, 
		string content, 
		DateTime created, 
		DateTime updated) : base(id)
	{
		Name = name;
		Content = content;
		Created = created;
		Updated = updated;
	}

	public string Name { get; } = null!;

	public string Content { get; } = null!;

	public DateTime Created { get; }

	public DateTime Updated { get; }

	public static ProjectFile Create(
		string name,
		string content,
		DateTime created,
		DateTime updated)
	{
		return new ProjectFile(
			ProjectFileId.CreateUnique(),
			name,
			content,
			created,
			updated);
	}

	protected ProjectFile()
	{

	}
}