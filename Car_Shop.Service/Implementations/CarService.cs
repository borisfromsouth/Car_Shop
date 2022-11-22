using Car_Shop.DAL.Interfaces;
using Car_Shop.Domain;
using Car_Shop.Domain.Enum;
using Car_Shop.Domain.Response;
using Car_Shop.Domain.ViewModels.Car;
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

		public async Task<IBaseResponse<Car>> GetCar(int id)
		{
			var baseResponse = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.Get(id);
				if (car == null)
				{
					baseResponse.Description = "Элемент по id не найден";
					baseResponse.StatusCode = StatusCode.CarNotFound;
					return baseResponse;
				}
				baseResponse.Data = car;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Car>()
				{
					Description = $"[GetCar] : {ex.Message}",
					StatusCode = StatusCode.InternalDerverError
				};
			}
		}

		public async Task<IBaseResponse<Car>> GetByName(string name)
		{
			var baseResponse = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.GetByName(name);
				if (car == null)
				{
					baseResponse.Description = "Элемент по имени не найден";
					baseResponse.StatusCode = StatusCode.CarNotFound;
					return baseResponse;
				}
				baseResponse.Data = car;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Car>()
				{
					Description = $"[GetCar] : {ex.Message}",
					StatusCode = StatusCode.InternalDerverError
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeleteCar(int id)
		{
			var baseResponse = new BaseResponse<bool>();
			try
			{
				var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

				await _carRepository.Delete(car);
				return baseResponse;
			}
			catch (Exception ex)
			{
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalDerverError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
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
					Description = $"[GetCars] : {ex.Message}",
					StatusCode = StatusCode.InternalDerverError
				};
			}
        }

        public async Task<IBaseResponse<CarViewModels>> CreateCar(CarViewModels model)
        {
           var baseResponse = new BaseResponse<CarViewModels>();
			try
			{
				var car = new Car()
				{
					Description = model.Description,
					DateCreate = DateTime.Now,
					Speed = model.Speed,
					Model = model.Model,
					Price = model.Price,
					Name = model.Name,
					TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar)
				};
				
				await _carRepository.Create(car);
			}
			catch (Exception ex)
			{
				return new BaseResponse<CarViewModels>()
				{
					Description = $"[CreateCar] : {ex.Message}",
					StatusCode = StatusCode.InternalDerverError
				};
			}
			return baseResponse;
        }

		public async Task<IBaseResponse<Car>> Edit(int id, CarViewModels model)
        {
			var baseResponse = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.Get(id);
				if(car == null)
                {
					baseResponse.Description = "Car not found";
					baseResponse.StatusCode = StatusCode.Error;
					return baseResponse;
				}
				car.Name = model.Name;
				car.Description = model.Description;
				car.Model = model.Model;
				car.Speed = model.Speed;
				car.Price = model.Price;
				car.DateCreate = model.DateCreate;
				car.TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar);

				await _carRepository.Update(car);
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Car>()
				{
					Description = $"[UpdateCar] : {ex.Message}",
					StatusCode = StatusCode.InternalDerverError
				};
			}
			return baseResponse;
		}
	}
}
