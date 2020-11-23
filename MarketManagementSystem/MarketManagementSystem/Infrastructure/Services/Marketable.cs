﻿using MarketManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MarketManagementSystem.Infrastructure.Interfaces;
using MarketManagementSystem.Infrastructure.Enums;
using ConsoleTables;


namespace MarketManagementSystem.Infrastructure.Services
{

    public class Marketable : IMarketable
    {
        public List<Sale> Sales { get; set; }
        public Marketable() {
            List<Sale> sls = new List<Sale>();
        }

    
        
        List<Product> _products = new List<Product> {
           new Product{
               Name="ASTARACAY 500GR EKSTRA CAY",
               Price=14.85,
               Category=CategoryType.Drinks,
               Quantity=100,
               ProductCode="009068"
            },
           new Product{
               Name="YA 1LT ALBALI SIRESI",
               Price=2.60,
               Category=CategoryType.Drinks,
               Quantity=250,
               ProductCode="074084"
            },
           new Product{
               Name="BOLCI 160GR SOKOLAD FUNDUKLU T/Q",
               Price=30.40,
               Category=CategoryType.Sweets,
               Quantity=142,
               ProductCode="113175"
            },
           new Product{
               Name="KEYROAD POZAN KR970986",
               Price=1.10,
               Category=CategoryType.OfficeSupplies,
               Quantity=50,
               ProductCode="005631"
            }
        };
        public List<Product> Products => _products;

        public void AddProduct()
        {
            Console.InputEncoding = Encoding.UTF8;
            Product prod = new Product();

            #region productName
            Console.Write("Məhsulun adı: ");
            prod.Name = Console.ReadLine();
            #endregion

            #region ProductPrice
            Console.Write("Məhsulun qiyməti: ");
            double price;
            string priceVal = Console.ReadLine();
            while (!double.TryParse(priceVal, out price))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                priceVal = Console.ReadLine();
            }
            prod.Price = price;
            #endregion

            #region productCategory
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");
            Array nums = Enum.GetValues(typeof(CategoryType));
            foreach (var item in nums)
            {
                Console.WriteLine(Array.IndexOf(nums, item) + " - " + item);
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.Write("Məhsulun kateqoriyası: ");
            string category = Console.ReadLine();
            try
            {
                prod.Category = (CategoryType)Enum.Parse(typeof(CategoryType), category);
            }
            catch
            {
                Console.WriteLine("Bu kategoriya movcud deyil");
                Console.WriteLine($"\"{category}\" adlı kateqoriya əlavə edə bilərsiniz.");
                return;
            }
            #endregion

            #region productQuantitiy
            Console.Write("Məhsulun miqdarı: ");
            int quant;
            string quantity = Console.ReadLine();
            while (!int.TryParse(quantity, out quant))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                quantity = Console.ReadLine();
            }
            prod.Quantity = quant;
            #endregion

            #region productCode
            Console.Write("Məhsulun kodu: ");
            prod.ProductCode = Console.ReadLine();
            #endregion

            _products.Add(prod);

            Console.WriteLine("\n Məhsul əlavə edildi. \n");
            Console.WriteLine("Məhsullar üzərində əməliyyat aparmaq üçün 0-7 intervalında rəqəm daxil edin: ");
            Console.WriteLine(" 1 - Yeni mehsul elave et\n" +
                            " 2 - Mehsul uzerinde duzelis et\n" +
                            " 3 - Mehsulu sil\n" +
                            " 4 - Butun mehsullari goster\n" +
                            " 5 - Categoriyasina gore mehsullari goster\n" +
                            " 6 - Qiymet araligina gore mehsullari goster\n" +
                            " 7 - Mehsullar arasinda ada gore axtaris et\n" +
                            " 0 - Məhsullar üzrə əməliyyatlardan çıxış");
        }
      
        public void EditProdInfo()
        {
            Console.Write("Düzəliş etmək istədiyiniz məhsul kodunu daxil edin: ");
            string prodCode = Console.ReadLine();
            Console.InputEncoding = Encoding.UTF8;

            Product prod = Products.Find(p=>p.ProductCode==prodCode);
            if (prod!=null)
            {
                #region productName
                Console.WriteLine($"Məhsulun adı: {prod.Name}");
                Console.Write("Yeni ad: ");
                prod.Name = Console.ReadLine();
                Console.WriteLine("");
                #endregion

                #region ProductPrice
                Console.WriteLine($"Məhsulun qiyməti: {prod.Price}");
                Console.Write("Yeni dəyər: ");
                double price;
                string priceVal = Console.ReadLine();
                while (!double.TryParse(priceVal, out price))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz.");
                    priceVal = Console.ReadLine();
                }
                prod.Price = price;
                Console.WriteLine("");
                #endregion

                #region productCategory
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");
                Array nums = Enum.GetValues(typeof(CategoryType));
                foreach (var item in nums)
                {
                    Console.WriteLine(Array.IndexOf(nums, item) + " - " + item);
                }
                Console.WriteLine("----------------------------------------------------------");

                Console.WriteLine($"Məhsulun kateqoriyası: {prod.Category}");
                Console.Write("Kateqoriya daxil edin: ");
                string category = Console.ReadLine();
                try
                {
                    prod.Category = (CategoryType)Enum.Parse(typeof(CategoryType), category);
                }
                catch
                {
                    Console.WriteLine("Bu kategoriya movcud deyil");
                    Console.WriteLine($"\"{category}\" adlı kateqoriya əlavə edə bilərsiniz.");
                }
                Console.WriteLine("");
                #endregion

                #region productQuantitiy
                Console.WriteLine($"Məhsulun miqdarı: {prod.Quantity}");
                int quant;
                Console.Write("Yeni dəyəri: ");
                string quantity = Console.ReadLine();
                while (!int.TryParse(quantity, out quant))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz.");
                    quantity = Console.ReadLine();
                }
                prod.Quantity = quant;
                #endregion

            }
            else Console.WriteLine($"{prodCode} kodlu məhsul mövcud deyil.");
            Console.WriteLine("\nMəhsullar üzərində əməliyyat aparmaq üçün 0-7 intervalında rəqəm daxil edin: ");

        }

        public void DeleteProduct()
        {
            Console.Write("Silmək istədiyiniz məhsul kodunu daxil edin: ");
            string prodCode = Console.ReadLine();
            Product delItem = Products.Find(p => p.ProductCode == prodCode);
            if (delItem != null)
            {
                Products.Remove(delItem);
                Console.WriteLine($"{delItem.Name} məhsulu silindi.");
            }
            else Console.WriteLine($"{prodCode} kodlu məhsul mövcud deyil.");
        }
        public void ShowProducts(List<Product> lst)
        {
            if (lst.Count != 0)
            {
                var table = new ConsoleTable("No", "Kod", "Kateqoriya", " Məhsul", "Sayı", "Qiyməti");
                foreach (Product item in lst)
                {
                    table.AddRow(Products.IndexOf(item) + 1, item.ProductCode, item.Category, item.Name, item.Quantity, item.Price);
                }
                table.Write();

                Console.WriteLine("\nMəhsullar üzərində əməliyyat aparmaq üçün 0-7 intervalında rəqəm daxil edin: ");
                Console.WriteLine(" 1 - Yeni mehsul elave et\n" +
                                " 2 - Mehsul uzerinde duzelis et\n" +
                                " 3 - Mehsulu sil\n" +
                                " 4 - Butun mehsullari goster\n" +
                                " 5 - Categoriyasina gore mehsullari goster\n" +
                                " 6 - Qiymet araligina gore mehsullari goster\n" +
                                " 7 - Mehsullar arasinda ada gore axtaris et\n" +
                                " 0 - Məhsullar üzrə əməliyyatlardan çıxış");
            }
            else Console.WriteLine("Məhsul siyahısı mövcud deyil");
        }
        public void GetProductByCategory()
        {
            Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");
            Array nums = Enum.GetValues(typeof(CategoryType));
            foreach (var item in nums)
            {
                Console.WriteLine(Array.IndexOf(nums, item) + " - " + item);
            }
            Console.WriteLine("----------------------------------------------------------\n");
            Console.Write("Kategoriya adını və nömrəsini daxil edin: ");

            string category = Console.ReadLine();
            CategoryType ctgr;
            try
            {
                ctgr = (CategoryType)Enum.Parse(typeof(CategoryType), category);
            }
            catch
            {
                Console.WriteLine("Bu kategoriya movcud deyil");
                Console.WriteLine($"\"{category}\" adlı kateqoriya əlavə edə bilərsiniz.");
                return;
            }
            List<Product> products = Products.FindAll(p => p.Category == ctgr);
            if (products.Count != 0)
            {
                ShowProducts(products);
            }
            else Console.WriteLine($"{category} kateqoriyası mövcu deyil.");

        }
        public void GetProductByPriceRange()
        {
            Console.Write("Minimum qiymət: ");
            double minPrice;
            string inpMinPrice = Console.ReadLine();
            while (!double.TryParse(inpMinPrice, out minPrice))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                inpMinPrice = Console.ReadLine();
            }

            Console.Write("Maksimum qiymət: ");
            double maxPrice;
            string inpMaxPrice = Console.ReadLine();
            while (!double.TryParse(inpMaxPrice, out maxPrice))
            {
                Console.WriteLine("Rəqəm daxil etməlisiniz.");
                inpMaxPrice = Console.ReadLine();
            }
            List<Product> products = Products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
            ShowProducts(products);
        }
        public void GetProductByName()
        {
            Console.WriteLine("Məhsulun adı: ");
            string name=Console.ReadLine();
            List<Product> products = Products.FindAll(p => p.Name.Contains(name,StringComparison.OrdinalIgnoreCase));
            if (products.Count != 0)
            {
                ShowProducts(products);
            }
            else Console.WriteLine($"{name} adlı məhsul mövcud deyil.");

        }

        public void AddSale(int productCount) { }
        //{
        //    Sale sale = new Sale();
        //    Random SaleNumb = new Random();
        //    Console.WriteLine("Satış kodu: " + SaleNumb.Next(100000, 999999));
            
        //    for (int i = 0; i < productCount; i++)
        //    {
        //        SaleItem item = new SaleItem();
        //        Console.Write($"{i+1} Məhsulun kodu: ");
        //        string prodCode= Console.ReadLine();
        //        Product saledProd = Products.Find(p => p.ProductCode == prodCode);
        //        if (saledProd!=null && saledProd.Quantity>=productCount)
        //        {
        //            item.No = i + 1;
        //            item.ProductCode = prodCode;
        //            item.Name = saledProd.Name;
        //            item.Price = saledProd.Price;
        //            item.Quantity = saledProd.Quantity;
        //            item.prodCount = productCount;
        //            Console.WriteLine(item.Name);
        //            sale.SaleItems.Add(item);
        //            sale.Amount += item.Price * productCount;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"{prodCode} kodlu məhsul mövcud deyil!");
        //            continue;
        //        }
        //        Console.Write("Məhsulun sayı: ");

        //        string ItemCount=Console.ReadLine();
        //        int SaleItemCount;
        //        while (!int.TryParse(ItemCount, out SaleItemCount))
        //        {
        //            Console.WriteLine("Reqem daxil etmelisinz.");
        //            ItemCount = Console.ReadLine();
        //        }
        //    }
        //    sale.date = DateTime.Now;
        //    Console.WriteLine($"Məbləğ:         {sale.Amount}");
        //    Console.WriteLine(sale.date);

        //    Sales.Add(sale);
        //}

        public void DeleteSaleItem()
        {
            
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

        public List<Sale> GetSalesBySaleNo(string SaleNo)
        {
            throw new NotImplementedException();
        }

        public void ShowSales()
        {
            throw new NotImplementedException();
        }
    }
}
