
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryTrackingApp.Areas.Admin.Models;

public class Driver {
    
    public Guid Id {get; set;}
    public string GivenName {get; set;}
    public string MiddleName {get; set;}
    public string Surname {get; set;}
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get; set;}
    public string Gender {get; set;}
    public string LicenseIdNumber {get; set;}
     [DataType(DataType.Date)]
    public DateTime LicenseValidity {get; set;}

    // public string LicensePhoto  {get;set;}
    public string Email {get; set;}
    public string MobileNumber {get; set;}
}