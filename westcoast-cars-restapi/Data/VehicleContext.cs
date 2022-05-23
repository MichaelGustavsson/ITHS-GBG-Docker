using Microsoft.EntityFrameworkCore;
using westcoast_cars_restapi.Models;

namespace westcoast_cars_restapi.Data
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }
    }
}