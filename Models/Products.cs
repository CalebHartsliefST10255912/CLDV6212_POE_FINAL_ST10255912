﻿using ABC_Retail_ST10255912_POE.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC_Retail_ST10255912_POE.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        //Formatted Price
        [NotMapped]
        public string FormattedPrice
        {
            get
            {
                return $"R{Price:N2}";
            }
        }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryID { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        //Navigation Properties
        public virtual Category? Category { get; set; }
    }
}
