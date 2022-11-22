using Car_Shop.Domain;
using Car_Shop.Domain.Response;
using Car_Shop.Domain.ViewModels.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Shop.Service.Interfaces
{
	public interface ICarService
	{
		Task<IBaseResponse<IEnumerable<Car>>> GetCars();// select all

		Task<IBaseResponse<Car>> GetCar(int id);

		Task<IBaseResponse<Car>> GetByName(string name);
 
		Task<IBaseResponse<bool>> DeleteCar(int id);

		Task<IBaseResponse<CarViewModels>> CreateCar(CarViewModels model);

		Task<IBaseResponse<Car>> Edit(int id, CarViewModels model);
	}
}
