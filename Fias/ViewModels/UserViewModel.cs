using System;
using System.ComponentModel.DataAnnotations;
using Fias.Infrastructure.Attributes;

namespace Fias.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Ид")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите логин")]
        [MinLength(3, ErrorMessage = "Логин должен содержать не менее 3-х символов")]
        [Display(Name = "Логин", Prompt = "Введите логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(3, ErrorMessage = "Пароль должен содержать не менее 3-х символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвержение пароля", Prompt = "Введите пароль")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите Ваше имя")]
        [RussianRequired]
        [Display(Name = "Имя", Prompt = "Введите имя")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [Display(Name = "Адрес электронной почты", Prompt = "Введите адрес электронной почты")]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата рождения", Prompt = "Введите дату рождения")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\+7|7|8)+([0-9]){10})$")]
        [Display(Name = "Номер телефона", Prompt = "Введите номер телефона")]
        public string Phone { get; set; }
    }
}
