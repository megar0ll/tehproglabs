using System.ComponentModel.DataAnnotations;

namespace lab1._3.Models
{
    public class CalculatorModel
    {
        [Display(Name = "Первый операнд (sbyte)")]
        [Range(-128, 127, ErrorMessage = "Значение должно быть в диапазоне sbyte (-128..127)")]
        [Required(ErrorMessage = "Поле 'Первый операнд' обязательно для заполнения!")]
        public sbyte? Operand1 { get; set; }

        [Display(Name = "Второй операнд (sbyte)")]
        [Required(ErrorMessage = "Поле 'Второй операнд' обязательно для заполнения!")]
        [Compare("Operand1", ErrorMessage = "Второй операнд должен совпадать с первым операндом!")]
        public sbyte? Operand2 { get; set; }

        [Display(Name = "Операция")]
        [Required(ErrorMessage = "Пожалуйста, выберите операцию!")]
        public string? Operation { get; set; }

        public double Result { get; set; }
    }
}