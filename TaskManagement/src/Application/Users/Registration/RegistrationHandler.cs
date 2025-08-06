using CSharpFunctionalExtensions;
using FluentValidation;
using Shared;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Users.Fails;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Users.Registration
{
    public class RegistrationHandler : ICommandHandler<Guid, RegistrationCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<RegistrationRequest> _validator;
        private readonly IPasswordHasher _passwordHasher;

        public RegistrationHandler(
            IUsersRepository usersRepository,
            IValidator<RegistrationRequest> validator,
            IPasswordHasher passwordHasher)
        {
            _usersRepository = usersRepository;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<Guid, Failure>> Handle(RegistrationCommand registrationCommand)
        {
            var validatorResult = await _validator.ValidateAsync(registrationCommand.registrationRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.ToErrors();
                return errors;
            }

            Result<User?, Failure> emailResult = await _usersRepository.GetByEmailAsync(registrationCommand.registrationRequest.Mail);

            if (emailResult.IsFailure)
            {
                return emailResult.Error;
            }

            if (emailResult.Value != null)
            {
                return Errors.Users.EmailIsBusy().ToFailure();
            }

            string hashedPassword = _passwordHasher.HashPassword(registrationCommand.registrationRequest.Password);

            var user = new User
            {
                Id = new Guid(),
                FirstName = registrationCommand.registrationRequest.FirstName,
                LastName = registrationCommand.registrationRequest.LastName,
                Email = registrationCommand.registrationRequest.Mail,
                PasswordHash = hashedPassword,
            };

            Result<Guid, Failure> addResult = await _usersRepository.AddAsync(user);

            if (addResult.IsFailure)
            {
                return addResult.Error;
            }

            return addResult.Value;
        }
    }
}
