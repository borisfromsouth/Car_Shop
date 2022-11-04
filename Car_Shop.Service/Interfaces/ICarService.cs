using Car_Shop.Domain;
using Car_Shop.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Shop.Service.Interfaces
{
	public interface ICarService
	{
		Task<BaseResponse<IEnumerable<Car>>> GetCars();
	}
}
