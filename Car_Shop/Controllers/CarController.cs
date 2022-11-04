using Car_Shop.DAL.Interfaces;
using Car_Shop.Domain;
using Car_Shop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Car_Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
                return View(response.Data);
			}
            return RedirectToAction("Error");
        }
    }
}
