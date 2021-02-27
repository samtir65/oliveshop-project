using Microsoft.AspNetCore.Mvc;
using OliveShop.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;


public class ProductGroupComponent:ViewComponent
{
 private IGroupRepositori _grouprepositori;
 public ProductGroupComponent(IGroupRepositori grouprepositori )
 {
     _grouprepositori=grouprepositori;
 }
  public async Task<IViewComponentResult> InvokeAsync()
  {
   
    
     
      return View("/Views/Components/ProductGroupComponent.cshtml",_grouprepositori.showGroupProducts());
  
  }

}