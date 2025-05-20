using BackendTest.Models;
using BackendTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleRepository _vehicleService;

        public VehiclesController(VehicleRepository vehicleService)
        {
            _vehicleService = vehicleService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return Ok(vehicles);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVehicle = await _vehicleService.AddAsync(vehicle);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _vehicleService.UpdateAsync(id, vehicle);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _vehicleService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
