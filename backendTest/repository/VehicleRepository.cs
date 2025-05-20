using BackendTest.Models;

namespace BackendTest.Services
{
    public interface VehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(int id);
        Task<Vehicle> AddAsync(Vehicle dto);
        Task<bool> UpdateAsync(int id, Vehicle dto);
        Task<bool> DeleteAsync(int id);
    }
}
