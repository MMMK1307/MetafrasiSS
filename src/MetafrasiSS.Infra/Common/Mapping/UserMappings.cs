using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Infra.DataModels.Entity;

namespace MetafrasiSS.Infra.Common.Mapping;

public static class UserMappings
{
    public static User ToDomainUser(this DataUserModel dataUser)
    {
        return new User(
            UserId.Create(dataUser.Id),
            dataUser.UserName!,
            dataUser.Name,
            dataUser.Email!,
            dataUser.EmailConfirmed,
            dataUser.PasswordHash!,
            dataUser.Status,
            dataUser.Created,
            dataUser.Updated);
    }

    public static DataUserModel ToDataUser(this User domainUser)
    {
        return new DataUserModel()
        {
            Id = domainUser.Id.Value,
            Name = domainUser.Name,
            UserName = domainUser.UserName,
            Email = domainUser.Email,
            PasswordHash = domainUser.Password,
            Status = domainUser.Status,
            Created = domainUser.Created,
            Updated = domainUser.Updated,
            EmailConfirmed = domainUser.ConfirmedEmail
        };
    }
}