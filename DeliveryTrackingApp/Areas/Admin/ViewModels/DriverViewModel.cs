using DeliveryTrackingApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

public class NewDriverViewModel { 
    public Guid Id {get; set;}
    [Required(ErrorMessage = "Given name is required.")]
    public string GivenName {get; set;} = "";
    [Required(ErrorMessage = "Middle name is required.")]
    public string MiddleName {get; set;} = "";
    [Required(ErrorMessage = "Surname is required.")]
    public string Surname {get; set;} = "";
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of birth is required.")]
    public DateTime DateOfBirth {get; set;} = DateTime.Now;
    [Required(ErrorMessage = "Gender is required.")]
    public string Gender {get; set;} = "";
    [Required(ErrorMessage = "License ID number is required.")]
    public string LicenseIdNumber {get; set;} = "";
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "License validity is required.")]
    public DateTime LicenseValidity {get; set;} = DateTime.Now;
    [Required(ErrorMessage = "License image is required.")]
    public IFormFile? LicenseImage {get; set;}
    public string LicenseImagePath  {get;set;} = "";
    public string Address {get;set;} = "";
   
    [Required(ErrorMessage = "Mobile number is required.")]
    public string MobileNumber {get; set;} = "";
    
    [ForeignKey("AccountId")]
    public virtual Account Account {get;set;} = new Account();
    
  
}