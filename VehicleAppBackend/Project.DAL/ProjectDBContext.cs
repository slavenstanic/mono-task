using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.DAL;

public class ProjectDbContext : DbContext
{
    public DbSet<VehicleMake> VehicleMakes { get; set; } 
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehicleRegistration> VehicleRegistrations { get; set; }
    public DbSet<VehicleEngineType> VehicleEngineTypes { get; set; }
    public DbSet<VehicleOwner> VehicleOwners { get; set; }

    
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }
    
}
