
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeliveryTrackingApp.Areas.Admin.Models;

public class Driver {
    
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

    // public string LicensePhoto  {get;set;}
    [Required(ErrorMessage = "Email is required.")] 
    
    public string Email {get; set;} = "";
    [Required(ErrorMessage = "Mobile number is required.")]
    public string MobileNumber {get; set;} = "";

}