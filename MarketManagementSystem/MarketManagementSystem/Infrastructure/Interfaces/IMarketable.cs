using System;
using System.Collections.Generic;
using System.Text;
using MarketManagementSystem.Infrastructure.Models;

namespace MarketManagementSystem.Infrastructure.Interfaces
{
    interface IMarketable
    {
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; }
        public void AddProduct();
        public void EditProdInfo();
        public void GetProductByCategory();
        public void GetProductByPriceRange();
        public void GetProductByName();

        public void AddSale(int SaleItemCount);
        public void DeleteSaleItem();
        public void ShowSales();
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        public List<Sale> GetSalesByDay(DateTime day);
        public List<Sale> GetSalesByAmount(double minAmount, double maxAmount);
        public List<Sale> GetSalesBySaleNo(string SaleNo);
        
    }
}
