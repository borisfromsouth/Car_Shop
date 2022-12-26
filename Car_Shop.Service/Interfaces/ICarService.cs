using Car_Shop.Domain;
using Car_Shop.Domain.Response;
using Car_Shop.Domain.ViewModel.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Shop.Service.Interfaces
{
	public interface ICarService
	{
		BaseResponse<Dictionary<int, string>> GetTypes();

		IBaseResponse<List<Car>> GetCars();

		Task<IBaseResponse<CarViewModel>> GetCar(int id);

		Task<IBaseResponse<Dictionary<int, string>>> GetCar(string term);

		Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

		Task<IBaseResponse<bool>> DeleteCar(int id);

		Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
	}
}
