using System;
using System.Collections.Generic;

namespace MarketManagementSystem.Infrastructure.Models
{
   public class Sale
    {
        public int SaleNo;
        public double Amount;
        public List<SaleItem> SaleItems { get; set; }
        public DateTime date;
    }
}
