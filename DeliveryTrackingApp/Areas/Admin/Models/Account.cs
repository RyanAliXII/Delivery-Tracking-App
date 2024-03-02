using System.ComponentModel.DataAnnotations;

public class Account {
    public Guid Id {get; set;}
    [Required(ErrorMessage = "Email is required.")]
    public string Email {get; set;} = "";
    public string Password {get; set;} = "";
}