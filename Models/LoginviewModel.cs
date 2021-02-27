using   System.ComponentModel.DataAnnotations;
namespace OliveShop.Models
{
    
public class LoginviewModel
{
    [Display(Name="ایمیل")]
    [Required(ErrorMessage="لطفا ایمبل را وارد نمایید")]
    [EmailAddress]
    [MaxLength(300)]
    public string  Email { get; set; }
    [Display(Name="رمز عبور")]
    [Required]
    [DataType(DataType.Password)]
    [MaxLength(50)]
    public string Password { get; set; }
    [Display(Name="مرا بخاطر بسپار")]
    public bool Remember { get; set; }


}
    
    
}