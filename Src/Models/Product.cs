using System;
using System.ComponentModel.DataAnnotations;

namespace Aduaba.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public string ImageUrl { get; set; }
    }
}