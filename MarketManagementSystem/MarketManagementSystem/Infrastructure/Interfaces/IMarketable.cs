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
        public void DeleteSaleItem(string saleNo);
        public void ShowSales(List<Sale> sales);
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        public List<Sale> GetSalesByDay(DateTime day);
        public List<Sale> GetSalesByAmountRange(double mnAmount, double mxAmount);
        public Sale GetSalesBySaleNo(string SaleNo);
        
    }
}
