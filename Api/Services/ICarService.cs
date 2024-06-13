using Api.Models;

namespace Api.Services;


//fix this
public interface ICarService
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car> GetByIdAsync(int id);
    Task AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(int id);
}
