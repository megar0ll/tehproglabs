using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab2_1.Models
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Марка автомобиля")]
        [Required(ErrorMessage = "Поле 'Марка' обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Brand { get; set; } = string.Empty;

        [DisplayName("Модель")]
        [Required(ErrorMessage = "Поле 'Модель' обязательно для заполнения")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        public string Model { get; set; } = string.Empty;

        [DisplayName("Год выпуска")]
        [Required(ErrorMessage = "Поле 'Год выпуска' обязательно для заполнения")]
        [Range(1900, 2026, ErrorMessage = "Год выпуска должен быть от 1900 до 2026")]
        public int Year { get; set; }

        [DisplayName("Цена (руб.)")]
        [Required(ErrorMessage = "Поле 'Цена' обязательно для заполнения")]
        [Range(0, 100000000, ErrorMessage = "Цена должна быть от 0 до 100 000 000 руб.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Пробег (км)")]
        [Required(ErrorMessage = "Поле 'Пробег' обязательно для заполнения")]
        [Range(0, 1000000, ErrorMessage = "Пробег должен быть от 0 до 1 000 000 км")]
        public int Mileage { get; set; }

        [DisplayName("Тип топлива")]
        [Required(ErrorMessage = "Поле 'Тип топлива' обязательно для заполнения")]
        public string FuelType { get; set; } = string.Empty;

        [DisplayName("Описание автомобиля")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Описание не должно превышать 1000 символов")]
        public string? Description { get; set; }

        [DisplayName("Дата добавления")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}