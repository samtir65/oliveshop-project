using System.ComponentModel.DataAnnotations;
namespace OliveShop.Models
{


public class RegistrerViewModel
{
    
    [Display(Name="ایمیل")]
    [Required(ErrorMessage="لطفا {0} وارد نمایید")]
    [EmailAddress]
    [MaxLength(300)]
    public string  Email { get; set; }
    [Required(ErrorMessage="لطفا {0} وارد نمایید")]
    [Display(Name="کلمه عبور")]
    [DataType(DataType.Password)]
    [MaxLength(50)]
    public string password { get; set; }
    [Required(ErrorMessage="لطفا {0} وارد نمایید")]
    [Display(Name="تکرار کلمه عبور")]
    [DataType(DataType.Password)]
    [Compare("password",ErrorMessage="کلمه های عبور مغایرت دارند")]
    [MaxLength(50)]
    public string Repassword { get; set; }
}

}