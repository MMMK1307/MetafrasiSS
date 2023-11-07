using Mapster;
using MetafrasiSS.Application.ProjectApp.Commands.Create;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.Entities;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Models.ProjectModels;

namespace MetafrasiSS.Common.Mapping;

public class ProjectMapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateProjectModel, CreateProjectCommand>();
		config.NewConfig<Project, ProjectModel>()
			.Map(dest => dest.Files, src => src.Files.Adapt<List<ProjectFileModel>>());
	}
}

public static class ProjectMapping
{
	public static ProjectModel ToProjectModel(this Project project)
	{
		return new ProjectModel()
		{
			Id = ProjectId.Create(project.Id.Value),
			Name = project.Name,
			Description = project.Description,
			Files = project.Files.ToList().ToProjectFileModel(),
			Created = project.Created,
			Updated = project.Updated,
			UserId = project.UserId
		};
	}

	public static List<ProjectModel> ToProjectModel(this List<Project> projects)
	{
		List<ProjectModel> models = new();

		for (int i = 0; i < projects.Count; i++)
		{
			models.Add(projects[i].ToProjectModel());
		}

		return models;
	}

	public static ProjectFileModel ToProjectFileModel(this ProjectFile file)
	{
		return new ProjectFileModel()
		{
			Id = file.Id,
			Name = file.Name,
			Content = file.Content,
			Created = file.Created,
			Updated = file.Updated
		};
	}

	public static List<ProjectFileModel> ToProjectFileModel(this List<ProjectFile> file)
	{
		var models = new List<ProjectFileModel>();

		for (int i = 0; i < file.Count; i++)
		{
			models.Add(file[i].ToProjectFileModel());
		}

		return models;
	}
}