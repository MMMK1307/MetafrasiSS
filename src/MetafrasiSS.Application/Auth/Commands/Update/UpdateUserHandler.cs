using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Domain.UserAggregate;

namespace MetafrasiSS.Application.Auth.Commands.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateUserHandler(
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Id)
        {
            Name = request.Name,
            UserName = request.Username,
            Email = request.Email,
            Updated = _dateTimeProvider.UtcNow,
        };

        _ = await _userRepository.Update(user);

        return user;
    }
}