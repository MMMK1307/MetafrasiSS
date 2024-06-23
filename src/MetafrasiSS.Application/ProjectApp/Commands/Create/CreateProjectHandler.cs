using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.Entities;

namespace MetafrasiSS.Application.ProjectApp.Commands.Create;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ErrorOr<Project>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateProjectHandler(
        IProjectRepository projectRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _projectRepository = projectRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Project>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var files = new List<ProjectFile>();

        if (request.FileName != "")
        {
            files.Add(ProjectFile.Create(
                request.FileName,
                request.FileContent,
                _dateTimeProvider.UtcNow,
                _dateTimeProvider.UtcNow));
        }

        var project = Project.Create(
            request.Name,
            request.Description,
            files,
            _dateTimeProvider.UtcNow,
            _dateTimeProvider.UtcNow,
            request.UserId);

        var result = await _projectRepository.Create(project);

        return result;
    }
}