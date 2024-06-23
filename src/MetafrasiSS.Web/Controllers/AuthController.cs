using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Queries.GetUserByClaims;
using MetafrasiSS.Application.Auth.Queries.Login;
using MetafrasiSS.Application.Auth.Queries.Logout;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Web.Models.UserModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MetafrasiSS.Web.Controllers;

public class AuthController : BaseController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public IActionResult Login()
    {
        var model = new LoginUserModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        var command = new LoginQuery(user.Username, user.Password, user.RememberMe);

        var result = await _mediator.Send(command);

        if (result.IsError)
        {
            return Problem(result.Errors, View(user));
        }

        return ToHome();
    }

    public async Task<IActionResult> Logout()
    {
        var user = await _mediator.Send(new GetUserByClaimsQuery(User));

        if (user.IsError)
        {
            return Problem(user.Errors, View());
        }

        var result = await _mediator.Send(new LogoutQuery(UserId.Create(user.Value.Id.Value)));

        if (result.IsError)
        {
            return Problem(result.Errors, RedirectToAction(nameof(HomeController.Index)));
        }

        return ToHome();
    }
}