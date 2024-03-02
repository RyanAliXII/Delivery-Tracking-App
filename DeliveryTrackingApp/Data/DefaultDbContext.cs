

using DeliveryTrackingApp.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingApp.Data;
public class DefaultDbContext : DbContext {
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options){

    }
    public DbSet<Driver> Driver  { get; set; }
}