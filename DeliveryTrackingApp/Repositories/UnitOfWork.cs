using DeliveryTrackingApp.Data;

namespace DeliveryTrackingApp.Repositories;

public class UnitOfWork(DefaultDbContext dbContext) : IUnitOfWork {
    private readonly DefaultDbContext _dbContext = dbContext;
    public IDriverRepository DriverRepository { get; private set; } = new DriverRepository(dbContext);

    public void Save(){
            _dbContext.SaveChanges();
    }
}

public interface IUnitOfWork {
    public IDriverRepository DriverRepository {get;}
}