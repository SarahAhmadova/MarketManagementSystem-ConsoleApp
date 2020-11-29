using System;

namespace MarketManagementSystem.Infrastructure.Exceptions
{
  
    [Serializable]
    public class SaleNoException : Exception
    {
        public SaleNoException() { }
        public SaleNoException(string saleNo ) : base( $"{saleNo} nömrəli satış mövcud deyil!") { }
    }
}
