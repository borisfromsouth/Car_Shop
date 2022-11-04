using Car_Shop.DAL.Interfaces;
using Car_Shop.Domain;
using Car_Shop.Domain.Enum;
using Car_Shop.Domain.Response;
using Car_Shop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Shop.Service.Implementations
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;

		public CarService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<BaseResponse<IEnumerable<Car>>> GetCars()
		{
			var baseResponse = new BaseResponse<IEnumerable<Car>>();
			try
			{
				var cars = await _carRepository.Select();
				if(cars.Count == 0)
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.StatusCode = StatusCode.OK;
					return baseResponse;
				}
				baseResponse.Data = cars;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch(Exception ex)
			{
				return new BaseResponse<IEnumerable<Car>>()
				{
					Description = $"[GetCars] : {ex.Message}"
				};
			}
		}
	}
}
