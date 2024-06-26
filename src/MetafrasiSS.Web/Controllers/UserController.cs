using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Commands.Register;
using MetafrasiSS.Application.Auth.Commands.Update;
using MetafrasiSS.Web.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace MetafrasiSS.Web.Controllers;

public class UserController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public UserController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterUserModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var command = _mapper.Map<RegisterUserCommand>(user);

        var result = await _mediator.Send(command);

        if (result.IsError)
        {
            Problem(result.Errors, View());
        }

        return RedirectToAction(controllerName: "Auth", actionName: "Login");
    }

    public IActionResult UpdateUser()
    {
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