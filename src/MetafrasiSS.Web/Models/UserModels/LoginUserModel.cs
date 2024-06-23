using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.UserModels;

public class LoginUserModel
{
    public LoginUserModel()
    {
        Username = "";
        Password = "";
        RememberMe = false;
    }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}