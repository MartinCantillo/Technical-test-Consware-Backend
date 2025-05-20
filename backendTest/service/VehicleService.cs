using BackendTest.data;
using BackendTest.Models;
using BackendTest.Services;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.service
{
    public class VehicleService : VehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleService(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vehicle> AddAsync(Vehicle entity)
        {
            _context.Vehicles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, Vehicle dto)
        {

            var existing = await _context.Vehicles.FindAsync(id);
            if (existing is null) return false;

            existing.Brand = dto.Brand;
            existing.Model = dto.Model;
            existing.Year = dto.Year;
            existing.Color = dto.Color;

            _context.Vehicles.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var occupation = await _context.Vehicles.FindAsync(id);
            if (occupation == null)
                return false;

            _context.Vehicles.Remove(occupation);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}