using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Car_Shop.Domain.ViewModel.Car
{
    public class CarViewModel
    {
        public int Id { get; set;}

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина - больше 2 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Модель")]
        [Required(ErrorMessage = "Укажите модель")]
        [MinLength(2, ErrorMessage = "Минимальная длина - больше 2 символов")]
        public string Model { get; set; }

        [Display(Name = "Скорость")]
        [Required(ErrorMessage = "Введите скорость")]
        [Range(0, 600, ErrorMessage = "Минимальная длина - больше 2 символов")]
        public double Speed { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Введите Цена")]
        public decimal Price { get; set; }

        public string DateCreate { get; set; }

        [Display(Name = "Тип автомобиля")]
        [Required(ErrorMessage = "Введите тип")]
        public string TypeCar { get; set; }

        public IFormFile Avatar { get; set; }

        public byte[]? Image { get; set; }
    }
}
