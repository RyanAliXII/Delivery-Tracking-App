using System.ComponentModel.DataAnnotations;

public class Account {
    [Required(ErrorMessage = "Email is required.")]
    public string Email {get; set;} = "";
    public string Password {get; set;} = "";
}