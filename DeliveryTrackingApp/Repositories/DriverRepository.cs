

using System.ComponentModel;
using DeliveryTrackingApp.Areas.Admin.Models;
using DeliveryTrackingApp.Areas.Admin.ViewModels;
using DeliveryTrackingApp.Data;
using DeliveryTrackingApp.Repositories;
using Microsoft.EntityFrameworkCore;

class DriverRepository: IDriverRepository {
    private readonly DefaultDbContext _dbContext;
    public DriverRepository(DefaultDbContext dbContext){
        _dbContext = dbContext;
    }
    public List<Driver> GetAll(){
         return _dbContext.Driver.ToList();
    }
    public Driver GetById(Guid id){
        var d = _dbContext.Driver.Where(d => d.Id == id).Include(d=> d.Account).FirstOrDefault() ?? new Driver();
        return  d;
    }
    public void Add(Driver driver){
        _dbContext.Driver.Add(driver);
        _dbContext.Account.Add(driver.Account);
        _dbContext.SaveChanges();
    }
  
    public void Update(Driver driver){
      _dbContext.Driver.Update(driver);
      _dbContext.Account.Update(driver.Account);
      _dbContext.SaveChanges();
    }
    public void Delete(Driver driver){
        
    }
    public List<DriverViewModel> GetAllDrivers(){
        return _dbContext.Driver.Include(d => d.Account).Select(d => new DriverViewModel(d)).ToList();
    }
    public bool IsLicenseIdNumberAlreadyRegistered(string idNumber){
        var d = _dbContext.Driver.Where(d => d.LicenseIdNumber.Equals(idNumber)).SingleOrDefault();
        return d != null;
    }
    public bool IsMobileNumberAlreadyRegistered(string mobileNumber){
        var d = _dbContext.Driver.Where(d => d.MobileNumber.Equals(mobileNumber)).SingleOrDefault();
        return d != null;
    }
    public bool IsEmailAlreadyRegistered(string email){
        var d = _dbContext.Driver.Include(d=> d.Account).Where(d => d.Account.Email.Equals(email)).SingleOrDefault();
        return d != null;
    }
}

public interface IDriverRepository: IRepository<Driver>{
    public List<DriverViewModel> GetAllDrivers();
    public bool IsLicenseIdNumberAlreadyRegistered(string idNumber);
    public bool IsMobileNumberAlreadyRegistered(string mobileNumber);
    public bool IsEmailAlreadyRegistered(string email);
   

}