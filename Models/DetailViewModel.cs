using OliveShop.Models;
using System.Collections.Generic;

public class DetailViewModel
{
    public DetailViewModel()
    {
        categories = new HashSet<Category>();

    }
    public Product product { get; set; }
    public ICollection<Category> categories { get; set; }


}