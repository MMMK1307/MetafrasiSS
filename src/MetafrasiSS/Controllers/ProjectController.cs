﻿using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Queries.GetUserByClaims;
using MetafrasiSS.Application.ProjectApp.Commands.Create;
using MetafrasiSS.Application.ProjectApp.Commands.Update;
using MetafrasiSS.Application.ProjectApp.Queries.GetProjectByUser;
using MetafrasiSS.Common.Mapping;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Models.ProjectModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MetafrasiSS.Controllers;

public class ProjectController : BaseController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public ProjectController(
		ISender mediator,
		IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<IActionResult> MyProjects()
	{
		var user = await _mediator.Send(new GetUserByClaimsQuery(User));

		if (user.IsError)
		{
			return default!;
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
			return default!;
		}

		var file = await ExtractFileContent(projectFile);

		project.Name = "Project Top";
		project.Description = "Thing";
		project.File.Name = file.Name;
		project.File.Content = file.Content;
		project.UserId = UserId.Create(user.Value.Id.Value);

		var command = new CreateProjectCommand(
			project.Name,
			project.Description,
			file.Name,
			file.Content,
			project.UserId);

		var result = await _mediator.Send(command);

		if (result.IsError)
		{
			return Problem(result.Errors, View());
		}

		return View();
	}

	public async Task<IActionResult> Update()
	{
		var user = await _mediator.Send(new GetUserByClaimsQuery(User));

		if (user.IsError)
		{
			return DefaultProblem(user.Errors);
		}

		var command = new GetProjectByUserQuery(UserId.Create(user.Value.Id.Value));
		var result = await _mediator.Send(command);

		return result.Match(
			project => View(project.ToProjectModel()),
			error => DefaultProblem(user.Errors));
	}

	[HttpPost]
	public async Task<IActionResult> Update(ProjectModel projectModel)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		var command = new UpdateProjectCommand(
			projectModel.Id,
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