using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Users.Fails
{
    public partial class Errors
    {
        public static class Users
        {
            public static Error UserNotFound()
            {
                return Error.NotFound("user.not.found", "Пользователь не найден");
            }

            public static Error EmailIsBusy()
            {
                return Error.Validation("email.is.busy", "Такая почта уже зарегистрирована");
            }

            public static Error IncorrectPassword()
            {
                return Error.Validation("password.is.incorrect", "Неверный пароль");
            }
        }
    }
}
