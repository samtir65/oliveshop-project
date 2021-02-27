using System.Collections.Generic;
namespace OliveShop.Models
{

public class Item
{
    public int ItemId { get; set; }

    public decimal Price { get; set; }
    //public mo Price { get; set; }
    public int QuantitiInStock { get; set; }
    
    //navigation property
    public Product product { get; set; }
}

    
}
