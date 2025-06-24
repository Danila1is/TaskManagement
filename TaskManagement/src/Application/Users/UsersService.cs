using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace Application.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<RegistrationRequest> _validator;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(IUsersRepository usersRepository, 
            IValidator<RegistrationRequest> validator,
            IPasswordHasher passwordHasher)
        {
            _usersRepository = usersRepository;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Registration(RegistrationRequest registrationRequest)
        {
            var validatorResult = await _validator.ValidateAsync(registrationRequest);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            if (await _usersRepository.GetByEmailAsync(registrationRequest.Mail) is not null)
            {
                throw new Exception("Такая почта уже зарегистрирована");
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
