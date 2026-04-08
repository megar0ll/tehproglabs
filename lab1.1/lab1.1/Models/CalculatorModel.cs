using System.ComponentModel.DataAnnotations;

namespace lab1._1.Models
{
    public class CalculatorModel
    {
        [Display(Name = "Первый операнд (sbyte)")]
        [Range(-128, 127, ErrorMessage = "Значение должно быть в диапазоне sbyte (-128..127)")]
        public sbyte Operand1 { get; set; }

        [Display(Name = "Второй операнд (double)")]
        public double Operand2 { get; set; }

        public string Operation { get; set; }

        public double Result { get; set; }
    }
}