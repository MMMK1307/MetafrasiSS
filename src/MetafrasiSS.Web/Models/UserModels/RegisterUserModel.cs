using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.UserModels;

public class RegisterUserModel
{
    public RegisterUserModel(
        string name,
        string username,
        string email,
        string password,
        string confirmPassword)
    {
        Name = name;
        Username = username;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public RegisterUserModel()
    {
    }

    [MaxLength(300)]
    [Required]
    public string Name { get; set; }

    [MaxLength(256)]
    [Required]
    public string Username { get; set; }

    [MaxLength(256)]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Must have more than 6 characters")]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}