using MarketManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MarketManagementSystem.Infrastructure.Interfaces;
using MarketManagementSystem.Infrastructure.Enums;

namespace MarketManagementSystem.Infrastructure.Services
{
    class Marketable : IMarketable
    {
        public List<Sale> Sales { get; set; }
        List<Product> _products = new List<Product>();
        public List<Product> Products => _products;
        

        public void AddProduct()
        {
            Console.InputEncoding = Encoding.UTF8;
            Product prod = new Product();
            prod.Name = "Kords";
            prod.Price = 2.50;
            prod.Quantity = 15;
            prod.ProductCode = "000158";
            prod.Category = CategoryType.Diary;
            Console.Write("Məhsulun adı: ");
            prod.Name = Console.ReadLine();
            Console.Write("Məhsulun qiyməti: ");
            double price;
            string priceVal = Console.ReadLine();
            while (!double.TryParse(priceVal, out price))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                priceVal = Console.ReadLine();
            }
            prod.Price = price;
            Console.Write("Məhsulun kateqoriyası: ");
            string category = Console.ReadLine();
            prod.Category = (CategoryType)Enum.Parse(typeof(CategoryType), category);
            Console.Write("Məhsulun miqdarı: ");
            int quant;
            string quantity = Console.ReadLine();
            while (!int.TryParse(quantity, out quant))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                quantity = Console.ReadLine();
            }
            prod.Quantity = quant;
            Console.Write("Məhsulun kodu: ");
            prod.ProductCode = Console.ReadLine();

            _products.Add(prod);

            foreach (var item in Products)
            {
                Console.WriteLine($"Name: {item.Name}\n" +
                    $"Price: {item.Price}\n" +
                    $"Quantity: {item.Quantity}\n" +
                    $"Code: {item.ProductCode}");
            }
        }

        public void AddSale(string prodName, int count)
        {
            throw new NotImplementedException();
        }

        public void ChangeProdInfo(int prodCode)
        {
            throw new NotImplementedException();
        }

        public void DeleteSaleItem()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public void GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByPriceRange(double price)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByAmount(double minAmount, double maxAmount)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesBySaleNo(int SaleNo)
        {
            throw new NotImplementedException();
        }

        public void ShowSales()
        {
            throw new NotImplementedException();
        }
    }
}
