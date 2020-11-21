using MarketManagementSystem.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketManagementSystem.Infrastructure.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryType Category;
        public int Quantity;
        public string ProductCode;
    }
}
