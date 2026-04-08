using System.ComponentModel.DataAnnotations;

namespace lab1._4.Models
{
    public class CalculatorModel
    {
        [Display(Name = "Operand 1 (sbyte)")]
        [Range(-128, 127, ErrorMessage = "Value must be in range -128..127")]
        [Required(ErrorMessage = "Operand 1 is required")]
        public sbyte? Operand1 { get; set; }

        [Display(Name = "Operand 2 (sbyte)")]
        [Required(ErrorMessage = "Operand 2 is required")]
        [Compare("Operand1", ErrorMessage = "Operand 2 must match Operand 1")]
        public sbyte? Operand2 { get; set; }

        [Display(Name = "Operation")]
        [Required(ErrorMessage = "Select operation")]
        public string? Operation { get; set; }

        public double Result { get; set; }
    }
}