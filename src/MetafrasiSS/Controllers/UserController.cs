using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Commands.Register;
using MetafrasiSS.Application.Auth.Commands.Update;
using MetafrasiSS.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace MetafrasiSS.Controllers;

public class UserController : BaseController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public UserController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public IActionResult RegisterUser()
	{
		return View();
	}

	public IActionResult UpdateUser()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> RegisterUser(RegisterUserModel user)
	{
		var command = _mapper.Map<RegisterUserCommand>(user);

		var result = await _mediator.Send(command);

		if (result.IsError)
		{
			Problem(result.Errors, View());
		}

		return View();
	}

	public async Task<IActionResult> UpdateUser(ListUserModel user)
	{
		var command = _mapper.Map<UpdateUserCommand>(user);

		var result = await _mediator.Send(command);

		if (result.IsError)
		{
			Problem(result.Errors, View());
		}

		return RedirectToAction(nameof(RegisterUser));
	}
}