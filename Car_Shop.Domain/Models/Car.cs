using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeCar TypeCar { get; set; }
    }

    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 0,

        [Display(Name = "Седан")]
        Sedan = 1,

        [Display(Name = "Хэтчбэк")]
        HatchBack = 2,

        [Display(Name = "Минивен")]
        Minivan = 3,

        [Display(Name = "Спортивная машина")]
        SportsCar = 4,

        [Display(Name = "Внедорожник")]
        Suv = 5
    }
}
