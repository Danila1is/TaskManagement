using CSharpFunctionalExtensions;
using FluentValidation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Users.Fails;
using TaskManagement.Application.Users.Fails.Exceptions;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace Application.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<RegistrationRequest> _validatorRegistration;
        private readonly IValidator<LoginRequest> _validatorLogin;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTProvider _jwtProvider;

        public UsersService(IUsersRepository usersRepository, 
            IValidator<RegistrationRequest> validator,
            IPasswordHasher passwordHasher,
            IValidator<LoginRequest> validatorLogin,
            IJWTProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _validatorRegistration = validator;
            _passwordHasher = passwordHasher;
            _validatorLogin = validatorLogin;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string, Failure>> LoginAsync(LoginRequest loginRequest)
        {
            // Check email and password
            var validatorResult = await _validatorLogin.ValidateAsync(loginRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.ToErrors();

                return errors;
            }

            Result<User?, Failure> emailResult = await _usersRepository.GetByEmailAsync(loginRequest.Email);

            if (emailResult.IsFailure)
            {
                return emailResult.Error;
            }

            if (emailResult.Value is null)
            {
                return Errors.Users.UserNotFound().ToFailure();
            }

            bool isValidPassword = _passwordHasher.VerifyPassword(loginRequest.Password, emailResult.Value.PasswordHash);

            if (!isValidPassword)
            {
                return Errors.Users.IncorrectPassword().ToFailure();
            }

            // create token

            string token = _jwtProvider.GenerateToken(emailResult.Value);

            // save token in the cookie
            return token;
        }

        public async Task<Result<Guid, Failure>> RegistrationAsync(RegistrationRequest registrationRequest)
        {
            var validatorResult = await _validatorRegistration.ValidateAsync(registrationRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.ToErrors();
                return errors;
            }

            Result<User?, Failure> emailResult = await _usersRepository.GetByEmailAsync(registrationRequest.Mail);

            if (emailResult.IsFailure)
            {
                return emailResult.Error;
            }

            if (emailResult.Value != null)
            {
                return Errors.Users.EmailIsBusy().ToFailure();
            }

            string hashedPassword = _passwordHasher.HashPassword(registrationRequest.Password);

            var user = new User
            {
                Id = new Guid(),
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Email = registrationRequest.Mail,
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
