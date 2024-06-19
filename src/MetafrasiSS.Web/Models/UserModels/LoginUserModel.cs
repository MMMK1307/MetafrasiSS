using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.UserModels;

public class LoginUserModel
{
	[Required]
	public string Username { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;

	public bool RememberMe { get; set; }
}