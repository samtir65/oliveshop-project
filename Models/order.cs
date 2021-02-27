using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OliveShop.Models
{
    public class order
    {
        public order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Userid { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsFinaly { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }


    }
}