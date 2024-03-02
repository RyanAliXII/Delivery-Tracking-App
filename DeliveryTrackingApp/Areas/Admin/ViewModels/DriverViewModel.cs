
using DeliveryTrackingApp.Areas.Admin.Models;

namespace DeliveryTrackingApp.Areas.Admin.ViewModels;
public class DriverViewModel { 
    public Guid Id {get; set;}
    public string GivenName {get; set;} = "";
    public string MiddleName {get; set;} = "";
    public string Surname {get; set;} = "";
    public DateTime DateOfBirth {get; set;} = DateTime.Now;
    public string Gender {get; set;} = "";
    public string LicenseIdNumber {get; set;} = "";
    public DateTime LicenseValidity {get; set;} = DateTime.Now;
    public string LicenseImagePath  {get;set;} = "";
    public string Address {get;set;} = "";
    public string MobileNumber {get; set;} = "";
    public string Email {get; set;} = "";
    public DriverViewModel(){}
    public DriverViewModel(Driver d){
        Id = d.Id;
        GivenName = d.GivenName;
        MiddleName = d.MiddleName;
        Surname = d.Surname;
        DateOfBirth = d.DateOfBirth;
        Gender = d.Gender;
        LicenseIdNumber = d.LicenseIdNumber;
        LicenseValidity = d.LicenseValidity;
        LicenseImagePath = d.LicenseImagePath;
        Address = d.Address;
        MobileNumber = d.MobileNumber;
        Email = d.Account.Email;
    }
}