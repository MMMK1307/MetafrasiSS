using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.UserModels;

public class RegisterUserModel
{
	[MaxLength(300)]
	[Required]
	public string Name { get; set; } = null!;

	[MaxLength(256)]
	[Required]
	public string Username { get; set; } = null!;

	[MaxLength(256)]
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;

	[Required]
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = null!;
}