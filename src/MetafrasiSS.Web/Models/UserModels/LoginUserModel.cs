using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    [Required]
    [JsonRequired]
    public bool RememberMe { get; set; }
}