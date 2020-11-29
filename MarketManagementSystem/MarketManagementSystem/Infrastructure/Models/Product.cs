using MarketManagementSystem.Infrastructure.Enums;

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
