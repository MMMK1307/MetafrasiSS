using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.Common.Interfaces.Persistence;

public interface IProjectRepository
{
	Task<Project> Create(Project project);

	Task<Project> Update(Project newProject);

	Task<Project> Delete(Project project);

	Task<Project> GetById(ProjectId projectId);

	Task<List<Project>> GetByUser(UserId userId);
}