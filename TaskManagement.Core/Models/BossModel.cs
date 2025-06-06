﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Models
{
    public class BossModel
    {
        private BossModel(int id,string firstName, string lastName, string mail, string passwordHash, 
            string? phoneNumber = null, string? patronymic = null, DateOnly? birthday = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Birthday = birthday;
            Mail = mail;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get;}
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; }
        [StringLength(50, MinimumLength = 1)]
        public string? Patronymic { get; }
        public string? FullName => $"{FirstName} {LastName} {Patronymic}".Trim();
        public DateOnly? Birthday { get; }
        [Required]
        [EmailAddress]
        public string Mail { get; }
        [Phone]
        public string? PhoneNumber { get; }
        [Required]
        [StringLength(64, MinimumLength = 64)]
        public string PasswordHash { get; } 

        public static (BossModel boss, List<ValidationResult> errors) Create(int id, string firstName, string lastName,
            string mail, string passwordHash, string? phoneNumber = null, string? patronymic = null, DateOnly? birthday = null)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var boss = new BossModel(id, firstName, lastName, mail, passwordHash, 
                phoneNumber, patronymic, birthday);
            var contextValidation = new ValidationContext(boss);

            Validator.TryValidateObject(boss, contextValidation, errors);

            return (boss, errors);
        }
    }
}
