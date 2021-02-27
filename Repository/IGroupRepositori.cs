using Microsoft.AspNetCore.Mvc;
using OliveShop.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OliveShop.Models;
public  interface IGroupRepositori
{
    
    IEnumerable<Category> GetAllCategories();
    IEnumerable<ShowGroupProductViewModel> showGroupProducts();
    
}

public class GroupRepositori:IGroupRepositori
{
    private OliveshopContext _context;
    public GroupRepositori(OliveshopContext context)
    {
        _context=context;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _context.categories;
    }

    public IEnumerable<ShowGroupProductViewModel> showGroupProducts()
    {
        return _context.categories.Select(c=>new ShowGroupProductViewModel()
    {
      Groupid=c.CategoryId,
      name=c.Name,
      ProductCount=_context.CategoritoProducts.Count(g=>g.CategoryId==c.CategoryId)

    }).ToList();
    }
}