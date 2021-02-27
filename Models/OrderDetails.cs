using System.ComponentModel.DataAnnotations;
namespace OliveShop.Models
{
   public class OrderDetails
    {
        [Key]
        public int detailID { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Count { get; set; }
        
        public order Order { get; set; }
        public Product product { get; set; }

    }
}