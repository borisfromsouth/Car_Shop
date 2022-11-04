using Car_Shop.Domain;
using System.Threading.Tasks;

namespace Car_Shop.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
