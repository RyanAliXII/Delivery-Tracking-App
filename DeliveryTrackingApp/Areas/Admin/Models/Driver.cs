
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeliveryTrackingApp.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeliveryTrackingApp.Areas.Admin.Models;

public class Driver {
    public Guid Id {get; set;}
    public string GivenName {get; set;} = string.Empty;
    public string MiddleName {get; set;} = string.Empty;
    public string Surname {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get; set;} = DateTime.Now;
    public string Gender {get; set;} = string.Empty;
    public string LicenseIdNumber {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    public DateTime LicenseValidity {get; set;} = DateTime.Now;
    public string LicenseImagePath  {get;set;} = string.Empty;
    public string Address {get;set;} = string.Empty;
    public string MobileNumber {get; set;} = string.Empty;
    [ForeignKey("AccountId")]
    public virtual Account Account {get;set;} = new Account();

    public Driver (){}
    public Driver (NewDriverViewModel d){
        UpdateFromViewModel(d);
    }
    public Driver (EditDriverViewModel d){
       UpdateFromViewModel(d);
    }
    public void UpdateFromViewModel(EditDriverViewModel d){
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
        Account.Email = d.Account.Email;
    }
      public void UpdateFromViewModel(NewDriverViewModel d){
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
        Account.Email = d.Account.Email;
    }

    
}