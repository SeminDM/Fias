using System;
using System.ComponentModel.DataAnnotations;

namespace Fias.ViewModels
{
    public class AddressObjectViewModel
    {
        public Guid? Id { get; set; }
        public Guid? Guid { get; set; }
        public Guid? ParentGuid { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя объекта")]
        public string FormalName { get; set; }
        [Display(Name = "Сокращение")]
        [Required(ErrorMessage = "Введите сокращение для объекта")]
        public string ShortName { get; set; }
        [Display(Name = "Уровень")]
        //[Required(ErrorMessage = "Выберите уровень объекта")]
        [Range(1, 7, ErrorMessage = "Уровень не определен")]
        public AddressObjectLevel Level { get; set; }
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Укажите статус объекта")]
        [Range(0, 1, ErrorMessage = "0 или 1")]
        public int? Status { get; set; }
        [Display(Name = "Код региона")]
        [Required(ErrorMessage = "Введите код региона")]
        public string RegionCode { get; set; }
        [Display(Name = "Почтовый индекс")]
        [Required(ErrorMessage = "Введите почтовый индекс")]
        public string PostalCode { get; set; }

        public DateTime? UpdateDate { get; set; }
    }

    public enum AddressObjectLevel
    {
        Undefined,
        Region = 1,
        Area = 3,
        City = 4,
        Settlement = 6,
        Street = 7
    }
}
