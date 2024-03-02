

using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Data;
using DeliveryTrackingApp.Repositories;

class DriverRepository: IDriverRepository {
    private readonly DefaultDbContext _dbContext;
    public DriverRepository(DefaultDbContext dbContext){
        _dbContext = dbContext;
    }
    public List<Driver> GetAll(){
         return _dbContext.Driver.ToList();
    }
    public Driver GetById(Guid id){
        return new Driver();
    }
    public void Add(Driver driver){
        _dbContext.Driver.Add(driver);
        _dbContext.Account.Add(driver.Account);
        _dbContext.SaveChanges();
    }
    public void Update(Driver driver){

    }
    public void Delete(Driver driver){
        
    }
}

public interface IDriverRepository: IRepository<Driver>{

}