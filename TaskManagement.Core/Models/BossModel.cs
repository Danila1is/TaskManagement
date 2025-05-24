using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Models
{
    public class BossModel
    {
        const int MAX_NAME_LENGTH = 50;
        const int MAX_PHONE_NUMBER_LENGTH = 11;
        const int MAX_PASSWORD_HASH_LENGTH = 64;
        private BossModel(int id,string firstName, string lastName, DateOnly? birthday,
            string mail, string phoneNumber, string passwordHash, DateTimeOffset? createdDate,
            DateTimeOffset? modifiedDate, string patronymic = "")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Birthday = birthday;
            Mail = mail;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
        }

        public int Id { get; set; }
        public string FirstName { get;} 
        public string LastName { get; } 
        public string? Patronymic { get; }
        public string? FullName => $"{FirstName} {LastName} {Patronymic}".Trim();
        public DateOnly? Birthday { get; } 
        public string Mail { get; }
        public string PhoneNumber { get; } 
        public string PasswordHash { get; } 
        public DateTimeOffset? CreatedDate { get; } 
        public DateTimeOffset? ModifiedDate { get; }

        public static (BossModel boss, string Error) Create(int id, string firstName, string lastName, DateOnly? birthday,
            string mail, string phoneNumber, string passwordHash, DateTimeOffset? createdDate,
            DateTimeOffset? modifiedDate, string patronymic = "")
        {
            string error = Validation(firstName, lastName, phoneNumber, passwordHash, patronymic);

            var boss = new BossModel(id, firstName, lastName, birthday,
            mail, phoneNumber, passwordHash, createdDate,
            modifiedDate, patronymic = "");

            return (boss, error);
        }

        private static string Validation(string firstName, string lastName, string phoneNumber, string passwordHash, string patronymic = "")
        {
            string error = string.Empty;

            if ((firstName.Length | lastName.Length | patronymic.Length) > 50)
            {
                error = "FirstName or LastName or Patronymic exceeds 50 characters";
                return error;
            }

            if(phoneNumber.Length > 11)
            {
                error = "PhoneNumber exceeds 11 characters";
                return error;
            }

            if (passwordHash.Length > 64)
            {
                error = "PasswordHash exceeds 64 characters";
                return error;
            }

            return error;
        }
    }
}
