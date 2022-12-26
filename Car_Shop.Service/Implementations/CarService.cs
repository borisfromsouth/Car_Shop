using Car_Shop.DAL.Interfaces;
using Car_Shop.Domain;
using Car_Shop.Domain.Enum;
using Car_Shop.Domain.Extensions;
using Car_Shop.Domain.Response;
using Car_Shop.Domain.ViewModel.Car;
using Car_Shop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Shop.Service.Implementations
{
	public class CarService : ICarService
	{
		private readonly IBaseRepository<Car> _carRepository;

		public CarService(IBaseRepository<Car> carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
		{
			try
			{
				var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (car == null)
				{
					return new BaseResponse<CarViewModel>()
					{
						Description = "Пользовательл не найден",
						StatusCode = StatusCode.UserNotFound
					};
				}

				var data = new CarViewModel()
				{
					DateCreate = car.DateCreate.ToLongDateString(),
					Description = car.Description,
					Name = car.Name,
					Price = car.Price,
					TypeCar = car.TypeCar.ToString(),
					Speed = car.Speed,
					Model = car.Model,
					Image = car.Avatar,
				};

				return new BaseResponse<CarViewModel>()
				{
					StatusCode = StatusCode.OK,
					Data = data
				};

			}
			catch (Exception ex)
			{
				return new BaseResponse<CarViewModel>()
				{
					Description = $"[GetCar] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

        public async Task<IBaseResponse<Dictionary<int, string>>> GetCar(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<int, string>>();
            try
            {
				var cars = await _carRepository.GetAll()
					.Select(x => new CarViewModel()
					{
						Id = x.Id,
						Speed = x.Speed,
						Name = x.Name,
						Description = x.Description,
						Model = x.Model,
						DateCreate = x.DateCreate.ToLongDateString(),
						Price = x.Price,
						TypeCar = x.TypeCar.ToString(),
					})
					.Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
					.ToDictionaryAsync(x => x.Id, t => t.Name);
				
				baseResponse.Data = cars;
				return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
		{
			try
			{
				var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
					return new BaseResponse<bool>()
					{
						Description = "CarNotFound",
						StatusCode = StatusCode.CarNotFound,
						Data = false
					};
                }

				return new BaseResponse<bool>()
				{
					Data = true,
					StatusCode = StatusCode.OK
				};

			}
			catch (Exception ex)
			{
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Create(CarViewModel model, byte[] imageData)
        {
			try
			{
				var car = new Car()
				{
					Name = model.Name,
					Model = model.Model,
					Description = model.Description,
					DateCreate = DateTime.Now,
					Speed = model.Speed,
					TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
					Price = model.Price,
					Avatar = imageData
				};
				
				await _carRepository.Create(car);

				return new BaseResponse<Car>()
				{
					StatusCode = StatusCode.OK,
					Data = car
                };
			}
			catch (Exception ex)
			{
				return new BaseResponse<Car>()
				{
					Description = $"[Create] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
        }

		public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
			try
			{
				var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (car == null)
                {
					return new BaseResponse<Car>()
					{
						Description = "CarNotFound",
						StatusCode = StatusCode.CarNotFound
					};
				}

				car.Description = model.Description;
				car.Model = model.Model;
				car.Price = model.Price;
				car.Speed = model.Speed;
				car.DateCreate = DateTime.ParseExact(model.DateCreate, "yyyyMMdd HH:mm", null);
				car.Name = model.Name;

				await _carRepository.Update(car);

				return new BaseResponse<Car>()
				{
					Data = car,
					StatusCode = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Car>()
				{
					Description = $"[Edit] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
				var data = _carRepository.GetAll().ToList();
                if (!data.Any())
                {
					return new BaseResponse<List<Car>>()
					{
						Description = "Ничего не найдено",
						StatusCode = StatusCode.OK
					};
                }

				return new BaseResponse<List<Car>>()
				{
					Data = data,
					StatusCode = StatusCode.OK
				};
            }
			catch (Exception ex)
            {
				return new BaseResponse<List<Car>>()
				{
					Description = $"[GetCars] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
            }
        }

		public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
				var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar))).ToDictionary(k => (int)k, t => t.GetDisplayName());

				return new BaseResponse<Dictionary<int, string>>()
				{
					Data = types,
					StatusCode = StatusCode.OK
				};
            }
            catch (Exception ex)
            {
				return new BaseResponse<Dictionary<int, string>>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
        }

    }
}
