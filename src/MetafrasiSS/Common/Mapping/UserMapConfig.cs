using Mapster;
using MetafrasiSS.Application.Auth.Commands.Register;
using MetafrasiSS.Application.Auth.Queries.Login;
using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Infra.DataModels.Entity;
using MetafrasiSS.Models.UserModels;

namespace MetafrasiSS.Common.Mapping;

public class UserMapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<User, ListUserModel>();
		config.NewConfig<User, DataUserModel>();
		config.NewConfig<LoginUserModel, LoginQuery>();
		config.NewConfig<RegisterUserModel, RegisterUserCommand>();
	}
}