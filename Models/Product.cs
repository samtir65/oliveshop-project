using System.Collections.Generic;

namespace OliveShop.Models
{
    public class Product
    {
        public Product()
        {
            categoritoProducts = new HashSet<CategoritoProduct>();
            OrderDetails = new HashSet<OrderDetails>();

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }

        public int ItemId { get; set; }

        //navigation property
        public ICollection<CategoritoProduct> categoritoProducts { get; set; }
        public Item item { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }



    }


}
