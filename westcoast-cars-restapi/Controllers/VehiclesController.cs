using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_cars_restapi.Data;
using westcoast_cars_restapi.Models;

namespace westcoast_cars_restapi.Controllers;

[ApiController]
[Route("api/v1/vehicles")]
public class VehiclesController : ControllerBase
{
    private readonly VehicleContext _context;
    public VehiclesController(VehicleContext context)
    {
      _context = context;
    }

		[HttpPost]
		public async Task<ActionResult> AddVehicle(Vehicle vehicle){
			await _context.Vehicles.AddAsync(vehicle);
			await _context.SaveChangesAsync();
			return StatusCode(201);
		}

		[HttpGet]
		public async Task<ActionResult<List<Vehicle>>> ListAllVehicles(){
			var vehicles = await _context.Vehicles.ToListAsync();
			return Ok(vehicles);
		}
}