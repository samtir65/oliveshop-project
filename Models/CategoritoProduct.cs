using OliveShop.Models;
public class CategoritoProduct
{
    public int CategoryId { get; set; }
    public int ProductID { get; set; }

    //navigation property
    public Category  Category { get; set; }
    public Product product { get; set; }

}