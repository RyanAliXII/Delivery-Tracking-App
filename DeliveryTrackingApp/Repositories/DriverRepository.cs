

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
    public List<DriverViewModel> GetAllDrivers(){
        return _dbContext.Driver.Include(d => d.Account).Select(d => new DriverViewModel(d)).ToList();
    }
    public bool IsLicenseIdNumberAlreadyRegistered(string idNumber){
        var d = _dbContext.Driver.Where(d => d.LicenseIdNumber.Equals(idNumber.Trim())).First();
        return d != null;
    }
    public bool IsMobileNumberAlreadyRegistered(string mobileNumber){
        var d = _dbContext.Driver.Where(d => d.LicenseIdNumber.Equals(mobileNumber.Trim())).First();
        return d != null;
    }
    public bool IsEmailAlreadyRegistered(string email){
        var d = _dbContext.Driver.Include(d=> d.Account).Where(d => d.Account.Email.Equals(email.Trim())).First();
        return d != null;
    }
}

public interface IDriverRepository: IRepository<Driver>{
    public List<DriverViewModel> GetAllDrivers();
    public bool IsLicenseIdNumberAlreadyRegistered(string idNumber);
}