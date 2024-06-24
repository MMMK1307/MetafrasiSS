using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MetafrasiSS.Infra.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly IdDataContext _dbContext;

    public ProjectRepository(IdDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Project> Create(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<Project> Update(Project newProject)
    {
        _dbContext.Projects.Update(newProject);
        await _dbContext.SaveChangesAsync();

        return newProject;
    }

    public async Task<Project> Delete(Project project)
    {
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<Project> GetById(ProjectId projectId)
    {
        var project = await _dbContext.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

        if (project is null)
        {
            return default!;
        }

        return project;
    }

    public async Task<List<Project>> GetByUser(UserId userId)
    {
        var query = _dbContext.Projects.Where(x => x._userId == userId.Value).AsNoTracking();
        var projects = await query.ToListAsync();

        return projects;
    }
}