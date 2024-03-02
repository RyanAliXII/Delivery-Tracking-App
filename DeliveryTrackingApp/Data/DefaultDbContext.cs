

using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingApp.Data;
public class DefaultDbContext : DbContext {
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options){

    }
}