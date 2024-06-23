using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Queries.GetUserByClaims;
using MetafrasiSS.Application.ProjectApp.Commands.Create;
using MetafrasiSS.Application.ProjectApp.Commands.Update;
using MetafrasiSS.Application.ProjectApp.Queries.GetProjectById;
using MetafrasiSS.Application.ProjectApp.Queries.GetProjectByUser;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Web.Common.Mapping;
using MetafrasiSS.Web.Models.ProjectModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MetafrasiSS.Web.Controllers;

public class ProjectController : BaseController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ProjectController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> MyProjects()
    {
        var user = await _mediator.Send(new GetUserByClaimsQuery(User));

        if (user.IsError)
        {
            return ToLogin();
        }

        var command = new GetProjectByUserQuery(UserId.Create(user.Value.Id.Value));
        var result = await _mediator.Send(command);

        return result.Match(
            projects => View(projects.ToProjectModel()),
            error => DefaultProblem(user.Errors));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectModel project, IFormFile projectFile)
    {
        var user = await _mediator.Send(new GetUserByClaimsQuery(User));

        if (user.IsError)
        {
            return ToLogin();
        }

        var file = await ExtractFileContent(projectFile);

        var command = new CreateProjectCommand(
            project.Name,
            project.Description,
            file.Name,
            file.Content,
            UserId.Create(user.Value.Id.Value));

        var result = await _mediator.Send(command);

        return result.Match(
            project => RedirectToAction(nameof(MyProjects)),
            errors => Problem(errors, View()));
    }

    public async Task<IActionResult> Update(Guid projectId)
    {
        var command = new GetProjectByIdQuery(ProjectId.Create(projectId));
        var result = await _mediator.Send(command);

        return result.Match(
            project => View(project.ToProjectModel()),
            error => DefaultProblem(result.Errors));
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProjectModel projectModel, Guid id)
    {
        if (projectModel.Name == "" || projectModel.Description == "")
        {
            return View();
        }

        var command = new UpdateProjectCommand(
            ProjectId.Create(id),
            projectModel.Name,
            projectModel.Description);

        var result = await _mediator.Send(command);

        return result.Match(
            project => RedirectToAction(nameof(MyProjects)),
            errors => Problem(errors, View()));
    }

    private static async Task<(string Name, string Content)> ExtractFileContent(IFormFile file)
    {
        if (file == null)
        {
            return ("", "");
        }

        var fileContent = new StringBuilder();

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
            {
                fileContent.Append(await reader.ReadLineAsync());
                fileContent.Append('\n');
            }
        }

        return (file.FileName, fileContent.ToString());
    }
}