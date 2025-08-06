using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;

namespace TaskManagement.Application.Users.Registration
{
    public class RegistrationUserValidator: AbstractValidator<RegistrationRequest>
    {
        public RegistrationUserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().MaximumLength(30).WithMessage("Неправильно введено имя");
            RuleFor(user => user.LastName).NotEmpty().MaximumLength(30).WithMessage("Неправильно введена фамилия");
            RuleFor(user => user.Mail).NotEmpty().EmailAddress().WithMessage("Неправильно введен email");
            RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage("Ошибка в пароле");
        }
    }
}
