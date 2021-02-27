using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OliveShop.Data;

namespace OliveShop.Controllers
{


public class ProductController:Controller
{
    private OliveshopContext _context;
    public ProductController(OliveshopContext context)
    {
        _context=context;
    }
    [Route("Group/{id}/{name}")]
    public IActionResult ShowProductGroupID(int id ,string name)
        {
            ViewData["productname"]=name;
            var product=_context.CategoritoProducts.Where(c=>c.CategoryId==id)
            .Include(p=>p.product).Select(p=>p.product).ToList();

            return View(product);


        }

}

}