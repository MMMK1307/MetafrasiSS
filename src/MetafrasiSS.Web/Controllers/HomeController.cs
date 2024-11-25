using MetafrasiSS.Web.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace MetafrasiSS.Web.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string culture)
    {
        if (string.IsNullOrEmpty(culture))
        {
            return View();
        }

        try
        {
            var cultureInfo = new CultureInfo(culture);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureInfo)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }
        catch (CultureNotFoundException)
        {
            return View();
        }

        string returnUrl = Request.Headers["Referer"].ToString() ?? "/";

        return Redirect(returnUrl);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        _logger.LogError("Controller Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}