using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fias.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [MinLength(3, ErrorMessage = "Логин должен содержать не менее 3-х символов")]
        [Display(Name = "Логин", Prompt = "Введите логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(3, ErrorMessage = "Пароль должен содержать не менее 3-х символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        public string Password { get; set; }
    }
}
