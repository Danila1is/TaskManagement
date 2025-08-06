using CSharpFunctionalExtensions;
using FluentValidation;
using Shared;
using TaskManagement.Application.Extensions;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;
using TaskManagement.Application.Users.Fails;
using System.Windows.Input;
using TaskManagement.Application.Abstractions;

namespace TaskManagement.Application.Users.Login
{
    public class LoginHandler: ICommandHandler<string, LoginCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<LoginRequest> _validator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTProvider _jwtProvider;

        public LoginHandler(
            IUsersRepository usersRepository,
            IPasswordHasher passwordHasher,
            IValidator<LoginRequest> validatorLogin,
            IJWTProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _validator = validatorLogin;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string, Failure>> Handle(LoginCommand loginCommand)
        {
            // Check email and password
            var validatorResult = await _validator.ValidateAsync(loginCommand.loginRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.ToErrors();

                return errors;
            }

            Result<User?, Failure> emailResult = await _usersRepository.GetByEmailAsync(loginCommand.loginRequest.Email);

            if (emailResult.IsFailure)
            {
                return emailResult.Error;
            }

            if (emailResult.Value is null)
            {
                return Errors.Users.UserNotFound().ToFailure();
            }

            bool isValidPassword = _passwordHasher.VerifyPassword(loginCommand.loginRequest.Password, emailResult.Value.PasswordHash);

            if (!isValidPassword)
            {
                return Errors.Users.IncorrectPassword().ToFailure();
            }

            // create token

            string token = _jwtProvider.GenerateToken(emailResult.Value);

            // save token in the cookie
            return token;
        }
    }
}
