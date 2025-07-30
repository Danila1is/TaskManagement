using CSharpFunctionalExtensions;
using Shared;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace Application.Users
{
    public interface IUsersService
    {
        Task<Result<Guid, Failure>> RegistrationAsync(RegistrationRequest registrationRequest);

        Task<Result<string, Failure>> LoginAsync(LoginRequest loginRequest);
    }
}