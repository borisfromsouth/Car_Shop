using System.ComponentModel.DataAnnotations;

namespace Car_Shop.Domain.Enum
{
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
