using FluentValidation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<string> LoginAsync(LoginRequest loginRequest)
        {
            // Check email and password
            var validatorResult = await _validatorLogin.ValidateAsync(loginRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.Errors.Select(x => Error.Validation(x.ErrorCode, x.ErrorMessage, x.PropertyName)).ToArray();

                throw new UserValidationException(errors);
            }

            var user = await _usersRepository.GetByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                throw new UserNotFoundException([Errors.Users.UserNotFound()]);
            }

            bool isValidPassword = _passwordHasher.VerifyPassword(loginRequest.Password, user.PasswordHash);

            if (!isValidPassword)
            {
                throw new UserIncorrectPasswordException();
            }

            // create token

            string token = _jwtProvider.GenerateToken(user);


            // save token in the cookie

            

            return token;
        }

        public async Task<Guid> RegistrationAsync(RegistrationRequest registrationRequest)
        {
            var validatorResult = await _validatorRegistration.ValidateAsync(registrationRequest);

            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
                throw new UserValidationException(errors);
            }

            if (await _usersRepository.GetByEmailAsync(registrationRequest.Mail) is not null)
            {
                throw new UserEmailIsBusyException();
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

            Guid id = await _usersRepository.AddAsync(user);

            return id;
        }
    }
}
