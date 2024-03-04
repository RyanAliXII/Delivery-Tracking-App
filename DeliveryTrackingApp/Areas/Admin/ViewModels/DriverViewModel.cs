using DeliveryTrackingApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryTrackingApp.Areas.Admin.ViewModels;
public class DriverViewModel { 
    public Guid Id {get; set;}
    public string GivenName {get; set;} = string.Empty;
    public string MiddleName {get; set;} = string.Empty;
    public string Surname {get; set;} = string.Empty;
    public DateTime DateOfBirth {get; set;} = DateTime.Now;
    public string Gender {get; set;} = string.Empty;
    public string LicenseIdNumber {get; set;} = string.Empty;
    public DateTime LicenseValidity {get; set;} = DateTime.Now;
    public string LicenseImagePath  {get;set;} = string.Empty;
    public string Address {get;set;} = string.Empty;
    public string MobileNumber {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
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

public class MutateDriverViewModel { 
    public Guid Id {get; set;}
    [Required(ErrorMessage = "Given name is required.")]
    public string GivenName {get; set;} = string.Empty;
    [Required(ErrorMessage = "Middle name is required.")]
    public string MiddleName {get; set;} = string.Empty;
    [Required(ErrorMessage = "Surname is required.")]
    public string Surname {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of birth is required.")]
    public DateTime DateOfBirth {get; set;} = DateTime.Now;
    [Required(ErrorMessage = "Gender is required.")]
    public string Gender {get; set;} = string.Empty;
    [Required(ErrorMessage = "License ID number is required.")]
    public string LicenseIdNumber {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "License validity is required.")]
    public DateTime LicenseValidity {get; set;} = DateTime.Now;
    [Required(ErrorMessage = "License image is required.")]
    public IFormFile? LicenseImage {get; set;}
    public string LicenseImagePath  {get;set;} = string.Empty;
    public string Address {get;set;} = string.Empty;
   
    [Required(ErrorMessage = "Mobile number is required.")]
    public string MobileNumber {get; set;} = string.Empty;
    
    [ForeignKey("AccountId")]
    public virtual Account Account {get;set;} = new Account();
    
    public MutateDriverViewModel (){}
    public MutateDriverViewModel(Driver d){
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