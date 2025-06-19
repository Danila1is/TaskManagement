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

        public UsersService(IUsersRepository usersRepository, IValidator<RegistrationRequest> validator)
        {
            _usersRepository = usersRepository;
            _validator = validator;
        }

        public async Task<Guid> Registration(RegistrationRequest registrationRequest)
        {
            var validatorResult = await _validator.ValidateAsync(registrationRequest);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            if (!await _usersRepository.CheckEmailAsync(registrationRequest.Mail))
            {
                throw new Exception("Такая почта уже зарегистрирована");
            }

            // Нужно добавить хэширование пароля

            Guid id = Guid.NewGuid();

            var user = new User
            {
                Id = id,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Email = registrationRequest.Mail,
                PasswordHash = registrationRequest.Password,
            };

            await _usersRepository.AddAsync(user);

            return id;
        }
    }
}
