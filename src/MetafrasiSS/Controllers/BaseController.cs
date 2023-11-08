using ErrorOr;
using MetafrasiSS.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MetafrasiSS.Controllers;

public class BaseController : Controller
{
	public IActionResult Problem(List<Error> errors, IActionResult pageRedirect)
	{
		var builder = new StringBuilder();

		for (int i = 0; i < errors.Count; i++)
		{
			builder.Append($"Error. {errors[i].Description} \n");
		}

		TempData[Constants.ErrorMessage] = builder.ToString();

		return pageRedirect;
	}

	public IActionResult DefaultProblem(List<Error> errors)
	{
		return Problem(errors, RedirectToAction(nameof(HomeController.Index)));
	}
}