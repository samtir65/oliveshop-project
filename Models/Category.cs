using System.Collections.Generic;
namespace OliveShop.Models
{
    public class Category
    {
        public Category()
        {
            categoritoProducts = new HashSet<CategoritoProduct>();

        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //navigation
        public ICollection<CategoritoProduct> categoritoProducts { get; set; }

    }

}

