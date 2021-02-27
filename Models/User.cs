using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Userid { get; set; }
    [Display(Name="ایمیل")]
    [Required(ErrorMessage="لطفا {0} وارد نمایید")]
    [MaxLength(300)]
    public string Email { get; set; }
    [Display(Name="رمز عبور")]
     [Required(ErrorMessage="لطفا {0} وارد نمایید")]
     [DataType("password")]
     [MaxLength(50)]
    public string Password { get; set; }
    [Required]
    public DateTime RegisterDate { get; set; }
    public bool IsAdmin { get; set; }


}