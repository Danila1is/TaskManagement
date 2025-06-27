using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace Application.Users
{
    public interface IUsersService
    {
        Task<Guid> RegistrationAsync(RegistrationRequest registrationRequest);

        Task<string> LoginAsync(LoginRequest loginRequest);
    }
}