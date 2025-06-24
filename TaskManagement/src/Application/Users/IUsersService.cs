using TaskManagement.Contracts.Users;

namespace Application.Users
{
    public interface IUsersService
    {
        Task<Guid> Registration(RegistrationRequest registrationRequest);

    }
}