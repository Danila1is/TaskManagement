using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;

namespace TaskManagement.Application.Users.Login
{
    public class LoginUserValidator: AbstractValidator<LoginRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(login => login.Email).NotEmpty().WithMessage("Поле логина обязательно для заполнения!");
            RuleFor(login => login.Password).NotEmpty().WithMessage("Поле пароля обязательно для заполнения!");
        }
    }
}
