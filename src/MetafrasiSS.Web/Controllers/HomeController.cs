using MapsterMapper;
using MediatR;
using MetafrasiSS.Application.Auth.Commands.Register;
using MetafrasiSS.Application.Auth.Commands.Update;
using MetafrasiSS.Application.Auth.Queries.GetUserById;
using MetafrasiSS.Application.Auth.Queries.Login;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MetafrasiSS.Web.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, ISender mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Privacy1()
    {
        var command = new RegisterUserCommand("Jonas", "test", "jonasrobertotest@mailinator.com", "Jonas123!@#");

        var result = await _mediator.Send(command);

        return RedirectToAction(nameof(Privacy));
    }

    public async Task<IActionResult> Privacy2()
    {
        var d = User;

        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        //var command = new LoginQuery("test", "Jonas123!@#", false);
        var command = new LoginQuery("test", "Jonas123!@#", false);

        var result = await _mediator.Send(command);

        //var thing = User;
        //_ = thing!.Identity!.Name;

        if (result.IsError)
        {
            return Problem(result.Errors, RedirectToAction(nameof(Privacy)));
        }

        return RedirectToAction(nameof(Privacy));
    }

    public async Task<IActionResult> Privacy3()
    {
        var id = UserId.Create(Guid.Parse("f39b24ac-4728-452a-b4a8-4dc64fd61386"));

        var user = await _mediator.Send(new GetUserByIdQuery(id));

        var command = new UpdateUserCommand(id, user.Value.Name + "Changed", user.Value.UserName, user.Value.Email);

        var result = await _mediator.Send(command);

        return RedirectToAction(nameof(Privacy));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}