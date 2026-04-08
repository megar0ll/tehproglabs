using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab2_3.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DisplayName("Марка")]
        [Required(ErrorMessage = "Введите марку")]
        public string Brand { get; set; } = string.Empty;

        [DisplayName("Модель")]
        [Required(ErrorMessage = "Введите модель")]
        public string Model { get; set; } = string.Empty;

        [DisplayName("Год выпуска")]
        [Range(1900, 2026)]
        public int Year { get; set; }

        [DisplayName("Цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Пробег")]
        public int Mileage { get; set; }

        [DisplayName("Топливо")]
        public string FuelType { get; set; } = string.Empty;

        [DisplayName("Описание")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DisplayName("Дата добавления")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("В наличии")]
        public bool IsAvailable { get; set; }
    }
}