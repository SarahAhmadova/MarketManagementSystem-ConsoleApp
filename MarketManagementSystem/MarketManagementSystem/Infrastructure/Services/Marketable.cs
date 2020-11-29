using MarketManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using MarketManagementSystem.Infrastructure.Interfaces;
using MarketManagementSystem.Infrastructure.Enums;
using ConsoleTables;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MarketManagementSystem.Infrastructure.Services
{

    public class Marketable : IMarketable
    {
      
        private int SaleId = 1;
        public List<Sale> Sales { get; set; }
        public Marketable() {
            Console.OutputEncoding = Encoding.UTF8;

            // Default filled Sales List
            Sales = new List<Sale> {
                new Sale{
                    SaleNo=SaleId,
                    SaleItems = new List<SaleItem>
                    {
                        new SaleItem
                        {
                            No=1,
                            product=Products.Find(p=>p.ProductCode=="009068"),
                            prodCount=10
                        }

                    }
                    ,date=new DateTime(2020,11,20),
                    Amount= 210
                },
                new Sale{
                    SaleNo=++SaleId,
                    SaleItems = new List<SaleItem>
                    {
                        new SaleItem
                        {
                            No=1,
                            product = Products.Find(p=>p.ProductCode=="005631"),
                            prodCount=20
                        }

                    }
                    ,date=new DateTime(2020,11,22),
                    Amount= 70
                }
            };
            
        }
        List<Product> _products = new List<Product> {
           new Product{
               Name="ASTARAÇAY 500GR EKSTRA ÇAY",
               Price=14.85,
               Category=CategoryType.Drinks,
               Quantity=100,
               ProductCode="009068"
            },
           new Product{
               Name="YA 1LT ALBALI ŞİRƏSİ",
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


        #region Check Is Number
        public static T To<T>(string value)
        {
            bool converted = false;
            T numb = default(T);
            while (!converted)
            {
                try
                {
                    numb = (T)Convert.ChangeType(value, typeof(T));
                    converted = true;
                }
                catch
                {
                    converted = false;
                    Console.Write("Rəqəm daxil edin: ");
                    value = Console.ReadLine();
                }
            }
            return numb;
        }

        #endregion

        public void AddProduct()
        {
            
            Product prod = new Product();

            #region productName
            Console.Write("Məhsulun adı: ");
            prod.Name = Console.ReadLine();

            #endregion

            #region ProductPrice
            Console.Write("Məhsulun qiyməti: ");
            string priceVal = Console.ReadLine();
            prod.Price = To<double>(priceVal);
            #endregion

            #region productCategory

            // ------------------------------------   SHOW CATEGORIES ---------------------------------------

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");

            Array nums = Enum.GetValues(typeof(CategoryType));
            foreach (var item in nums)
            {
                Console.WriteLine(Array.IndexOf(nums, item) + " - " + item );
            }
            Console.WriteLine("----------------------------------------------------------");

            // --------------------------------------  ASSIGN CATEGORY ---------------------------------------

            Console.Write("Məhsulun kateqoriyası: ");
            string category = Console.ReadLine();

            CategoryType ctgr;
             while (!Enum.TryParse(category, out ctgr) || !Enum.IsDefined(typeof(CategoryType), ctgr))
            {
                Console.WriteLine($"\"{category}\" adlı kateqoriya mövcud deyil. Yenidən cəhd edin.");
                Console.Write("Məhsulun kateqoriyası: ");
                category = Console.ReadLine();
            }

            prod.Category = ctgr;

            #endregion

            #region productQuantitiy
            Console.Write("Məhsulun miqdarı: ");
            string quantity = Console.ReadLine();
            prod.Quantity = To<int>(quantity);
            #endregion

            #region productCode
            Console.Write("Məhsulun kodu: ");
            prod.ProductCode = Console.ReadLine();
            #endregion

            _products.Add(prod);
        }
      
        public void EditProdInfo(string ProductCode)
        {
            
            Product prod = Products.Find(p=>p.ProductCode==ProductCode);
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
                string price = Console.ReadLine();
                prod.Price = To<double>(price);
                Console.WriteLine("");
                #endregion

                #region productCategory

                // -------------------------------------- SHOW CATEGORIES ----------------------------------------

                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");
                Array nums = Enum.GetValues(typeof(CategoryType));
                foreach (var item in nums)
                {
                    Console.WriteLine(Array.IndexOf(nums, item) + " - " + item);
                }
                Console.WriteLine("----------------------------------------------------------");

                // -------------------------------------- ASSIGN CATEGORY ------------------------------------------

                Console.WriteLine($"Məhsulun kateqoriyası: {prod.Category}");
                Console.Write("Kateqoriya daxil edin: ");
                string category = Console.ReadLine();

                CategoryType ctgr;
                while (!Enum.TryParse(category, out ctgr) || !Enum.IsDefined(typeof(CategoryType), ctgr))
                {
                    Console.WriteLine($"\"{category}\" adlı kateqoriya mövcud deyil. Yenidən cəhd edin.");
                    Console.Write("Məhsulun kateqoriyası: ");
                    category = Console.ReadLine();
                }

                prod.Category = ctgr;
                Console.WriteLine("");
                #endregion

                #region productQuantitiy
                Console.WriteLine($"Məhsulun miqdarı: {prod.Quantity}");
                Console.Write("Yeni miqdarı: ");
                string quantity = Console.ReadLine();
                prod.Quantity = To<int>(quantity);
                #endregion

                Console.WriteLine($"\"{ProductCode}\" kodlu məhsul məlumatlarına düzəliş edildi. ");

            }
            else Console.WriteLine($"{ProductCode} kodlu məhsul mövcud deyil.");
        }

        public void DeleteProduct(string ProductCode)
        {
            Product delItem = Products.Find(p => p.ProductCode == ProductCode);
            if (delItem != null)
            {
                Products.Remove(delItem);
                Console.WriteLine($"{delItem.Name} məhsulu silindi.");
            }
            else Console.WriteLine($"{ProductCode} kodlu məhsul mövcud deyil.");
        }

        // ------------------ SHOWS SELECTED PRODUCT LIST ON CONSOLE --------------------
        public void ShowProducts(List<Product> list)
        {

            if (list.Count != 0)
            {
                var table = new ConsoleTable("No", "Kod", "Kateqoriya", " Məhsul", "Sayı", "Qiyməti");
                foreach (Product item in list)
                {
                    table.AddRow(Products.IndexOf(item) + 1, item.ProductCode, item.Category, item.Name, item.Quantity, item.Price);
                }
                table.Write();
            }
            else Console.WriteLine("Məhsul siyahısı boşdur.");
        }

        
        public void GetProductByCategory(string category)
        {
           
            CategoryType ctgr;
            while (!Enum.TryParse(category, out ctgr) || !Enum.IsDefined(typeof(CategoryType), ctgr))
            {
                Console.WriteLine($"\"{category}\" adlı kateqoriya mövcud deyil. Yenidən cəhd edin.");
                Console.Write("Kateqoriya: ");
                category = Console.ReadLine();
            }


            List<Product> products = Products.FindAll(p => p.Category == ctgr);
            if (products.Count != 0)
            {
                ShowProducts(products);
            }
            else Console.WriteLine($"{category} kateqoriyasında məhsul mövcud deyil.");

        }

        public void GetProductByPriceRange(string minPrice, string maxPrice)
        {
            if (To<double>(minPrice) <= To<double>(maxPrice))
            {
                List<Product> products = Products.FindAll(p => p.Price >= To<double>(minPrice) && p.Price <= To<double>(maxPrice));
                ShowProducts(products);
            }
            else Console.WriteLine("Məbləğ aralığı düzgün daxil edilməyib");
        }
        public List<Product> GetProductByName(string productName)
        {
            return Products.FindAll(p => p.Name.Contains(productName,StringComparison.OrdinalIgnoreCase));            
        }

        public void AddSale() 
        {
            Sale sale = new Sale();
            sale.SaleNo = ++SaleId;
            sale.SaleItems = new List<SaleItem>();
            ConsoleKeyInfo key=default(ConsoleKeyInfo);
            int i = 1;
            do
            {
                SaleItem item = new SaleItem();
                Console.Write($"\n{i} Məhsulun kodu: ");
                string prodCode = Console.ReadLine();
                Product saledProd = Products.Find(p => p.ProductCode == prodCode);
                if (saledProd != null)
                {
                    Console.Write("Məhsulun sayı: ");
                    string ItemCount = Console.ReadLine();
                    int SaleItemCount = To<int>(ItemCount);
                    while (SaleItemCount == 0)
                    {
                        Console.Write("Məhsulun sayı 0 ola bilməz. Yenidən daxil edin: ");
                        ItemCount = Console.ReadLine();
                        SaleItemCount = To<int>(ItemCount);
                    }
                    if (saledProd.Quantity == 0)
                    {
                        Console.WriteLine($"{prodCode} kodlu məhsul bitib!");
                        continue;
                    }
                    else if (saledProd.Quantity >= SaleItemCount)
                    {
                        item.prodCount = SaleItemCount;
                        saledProd.Quantity -= SaleItemCount;
                    
                    }
                    else
                    {
                        item.prodCount = saledProd.Quantity;
                        saledProd.Quantity = 0;
                        
                    }

                    item.No = i;
                    item.product = saledProd;
                    Console.WriteLine(saledProd.Name);
                    sale.SaleItems.Add(item);
                    sale.Amount += saledProd.Price * item.prodCount;
                    i++;

                }
                else
                {
                    Console.WriteLine($"{prodCode} kodlu məhsul mövcud deyil!");
                    continue;
                }
                Console.WriteLine("Prosesi dayandırmaq üçün \"Sapce\" düyməsini, davam etmək üçün isə digər istənilən düyməni klikləyin.");
                key = Console.ReadKey();
            } while (key.Key!=ConsoleKey.Spacebar);

            sale.date = DateTime.Now;

            if (sale.SaleItems.Count > 0)
            {
                Sales.Add(sale);
                showSale(sale.SaleNo.ToString());
                Console.WriteLine("Satış əlavə edildi!");
            }
            else Console.WriteLine("Satış əlavə edilmədi!");
        }

        public void showSale(string SaleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == SaleNo);
            if (sale != null) {
                Console.WriteLine();
                if (sale.SaleItems.Count > 0)
                {
                    var table = new ConsoleTable("No", "Item No", "Product Name", "Count", "Price", "Amount");
                    int i = 1;
                    foreach (var item in sale.SaleItems)
                    {
                        table.AddRow(i, item.No, item.product.Name, item.prodCount, item.product.Price, (item.prodCount * item.product.Price).ToString("0.00"));
                        i++;
                    }
                    sale.Amount = sale.SaleItems.Sum(s => s.prodCount * s.product.Price);

                    table.AddRow("", "", "", "", "", "");
                    table.AddRow("Total Amount:", "", "", "", "", sale.Amount.ToString("0.00"));
                    table.AddRow("Date: ", sale.date, "", "", "", "");

                    table.Write((Format.Minimal));

                }
                else Console.WriteLine("Satış siyahısı boşdur!");
            }
            else Console.WriteLine($"{SaleNo} nömrəli satış mövcud deyil.");
        }
        public void DeleteSaleItem(string saleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == saleNo);
            if (sale != null)
            {
                Console.Write("Çıxarılacaq məhsulun nömrəsi: ");
                string prodNo = Console.ReadLine();
                int No = To<int>(prodNo);
                SaleItem item = sale.SaleItems.Find(s => s.No == No);
                if (item != null)
                {
                    Console.Write("Çıxarılacaq məhsulun sayı: ");
                    
                    string count= Console.ReadLine();
                    int delProdCount = To<int>(count);

                    if (delProdCount <= item.prodCount)
                    {
                        item.prodCount -= delProdCount;
                        if (item.prodCount == 0)
                        {
                            sale.SaleItems.Remove(item);
                        }
                        Products.Find(p => p.ProductCode == item.product.ProductCode).Quantity += delProdCount;
                        Console.WriteLine("Məhsul satışdan silindi.");
                        showSale(saleNo);
                    }
                    else Console.WriteLine($"{count} miqdardan az satılıb.");
                }
                else Console.WriteLine("Məhsul nömrəsi düzgün daxil edilməyib!");
            }
            else Console.WriteLine($"{saleNo} nömrəli satış mövcud deyil!");
        }
        public void DeleteSale(string saleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == saleNo);
            if (sale != null)
            {
                List<SaleItem> saleItems = sale.SaleItems;
                foreach  (SaleItem item in saleItems)
                {
                  Products.Find(p=>p.ProductCode==item.product.ProductCode).Quantity+= item.prodCount;
                }
                Sales.Remove(sale);
            }
            else Console.WriteLine($"{saleNo} nömrəli satış mövcud deyil!");
        }

        public List<Sale> GetSalesByAmountRange(double mnAmount, double  mxAmount)
        {
            return Sales.FindAll(s => s.Amount >= mnAmount && s.Amount <= mxAmount);
        }

        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return Sales.FindAll(s => s.date.Date >= startDate.Date && s.date.Date <= endDate.Date);
        }

        public List<Sale> GetSalesByDay(DateTime day)
        {
            return Sales.FindAll(s => s.date.Date == day.Date);
        }

        public Sale GetSalesBySaleNo(string SaleNo)
        {
            return Sales.Find(s => s.SaleNo.ToString() == SaleNo);
        }

        public void ShowSales(List <Sale> sales)
        {
            if (sales.Count > 0)
            {
                var table = new ConsoleTable("No", "Məhsul sayı", "Məbləğ", "Tarix");
                int i = 1;
                foreach (Sale item in sales)
                {
                    table.AddRow(i, item.SaleItems.Count, item.Amount.ToString("0.00"), item.date);
                    i++;
                }
                table.Write();
            }
            else Console.WriteLine("Satış siyahısı boşdur.");
        }
    }
}
