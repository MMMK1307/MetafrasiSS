using MetafrasiSS.Domain.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace MetafrasiSS.Infra.DataModels.Entity;

public class DataUserModel : IdentityUser<Guid>
{
    public DataUserModel()
    { }

    public string Name { get; set; } = null!;
    public UserStatus Status { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}