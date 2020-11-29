using System;

namespace MarketManagementSystem.Infrastructure.Exceptions
{
    [Serializable]
    public class ProdCodeException : Exception
    {
        public ProdCodeException() { }
        public ProdCodeException(string code) : base($"{code} kodlu məhsul mövcud deyil!") { }
    }
    
    public class ProdCategoryException : Exception
    {
        public ProdCategoryException() { }
        public ProdCategoryException(string category) : base($"{category} kateqoriyasında məhsul mövcud deyil.") { }
    }
}
