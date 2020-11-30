using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarketManagementSystem.Infrastructure.Models;
using MarketManagementSystem.Infrastructure.Exceptions;
using MarketManagementSystem.Infrastructure.Interfaces;
using MarketManagementSystem.Infrastructure.Enums;
using ConsoleTables;


namespace MarketManagementSystem.Infrastructure.Services
{

    public class Marketable : IMarketable
    {
        private int SaleId = 1;
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; set; }

        // ========================== FILL LISTS ===================================
        public Marketable() {
            Console.OutputEncoding = Encoding.UTF8;
            Sales = new List<Sale>();
            Products = new List<Product>();

            // ====================== Default filled PRODUCT List ==========================
            Products = _products;

            // ====================== Default filled SALE List ==========================
            //Sales = new List<Sale> {
            //    new Sale{
            //        SaleNo=SaleId++,
            //        SaleItems = new List<SaleItem>
            //        {
            //            new SaleItem
            //            {
            //                No=1,
            //                product=Products.Find(p=>p.ProductCode=="009068"),
            //                prodCount=10
            //            }

            //        }
            //        ,date=new DateTime(2020,11,20),
            //        Amount= Products.Find(p=>p.ProductCode=="009068").Price*10
            //    },
            //    new Sale{
            //        SaleNo=SaleId++,
            //        SaleItems = new List<SaleItem>
            //        {
            //            new SaleItem
            //            {
            //                No=1,
            //                product = Products.Find(p=>p.ProductCode=="005631"),
            //                prodCount=20
            //            }

            //        }
            //        ,date=new DateTime(2020,11,22),
            //        Amount= Products.Find(p=>p.ProductCode=="005631").Price*20
            //    }
            //};

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


        #region Check Is Number
        /// <summary>
        /// Converts string value to Number type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
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

        // ========================== PRODUCT METHODS =============================
        #region Product

        /// <summary>
        /// Add product to Product List
        /// </summary>
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
            prod.Category = showCategories();
            #endregion

            #region productQuantitiy
            Console.Write("Məhsulun miqdarı: ");
            string quantity = Console.ReadLine();
            prod.Quantity = To<int>(quantity);
            #endregion

            #region productCode
            Console.Write("Məhsulun kodu: ");
            string prodCode = Console.ReadLine();
            while (Products.Find(p => p.ProductCode == prodCode) != null)
            {
                Console.WriteLine($"{prodCode} kodlu məhsul mövcuddur. Yeni kod daxil edin.");
                Console.Write("Məhsulun kodu: ");
                prodCode = Console.ReadLine();
            }
            prod.ProductCode = prodCode;
            #endregion

            Products.Add(prod);
        }

        /// <summary>
        /// Edit existing product data 
        /// </summary>
        /// <param name="ProductCode">Product Code</param>
        public void EditProdInfo(string ProductCode)
        {

            Product prod = Products.Find(p => p.ProductCode == ProductCode);
            if (prod != null)
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
                Console.WriteLine($"Məhsulun kateqoriyası: {prod.Category}");

                prod.Category = showCategories();
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
            else throw new ProdCodeException(ProductCode);
        }

        /// <summary>
        /// Delete product from Product List
        /// </summary>
        /// <param name="ProductCode">Product Code</param>
        public void DeleteProduct(string ProductCode)
        {
            Product delItem = Products.Find(p => p.ProductCode == ProductCode);
            if (delItem != null)
            {
                Products.Remove(delItem);
                Console.WriteLine($"{delItem.Name} məhsulu silindi.");
            }
            else throw new ProdCodeException(ProductCode);
        }

        /// <summary>
        /// Show product list 
        /// </summary>
        /// <param name="list">Product list to show</param>
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

        /// <summary>
        /// Show product list by selected Category
        /// </summary>
        /// <param name="category">Product Category</param>
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
            else throw new ProdCategoryException(category);

        }

        /// <summary>
        /// Show product list by selected Price range
        /// </summary>
        /// <param name="minPrice">Minimum price</param>
        /// <param name="maxPrice">Maximum price</param>
        public void GetProductByPriceRange(string minPrice, string maxPrice)
        {
            if (To<double>(minPrice) <= To<double>(maxPrice))
            {
                List<Product> products = Products.FindAll(p => p.Price >= To<double>(minPrice) && p.Price <= To<double>(maxPrice));
                ShowProducts(products);
            }
            else Console.WriteLine("Məbləğ aralığı düzgün daxil edilməyib");
        }

        /// <summary>
        /// Finds products by given text
        /// </summary>
        /// <param name="productName">Text to search consisting Product name</param>
        /// <returns>Product list by Name</returns>
        public List<Product> GetProductByName(string productName)
        {
            return Products.FindAll(p => p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Show existing product categories and requires to select one of shown categories
        /// </summary>
        /// <returns>Selected product category</returns>
        public CategoryType showCategories()
        {
            // ------------------------------------   SHOW CATEGORIES ---------------------------------------

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Məhsulun bu kategoriyaları arasında seçim edə bilərsiniz: ");

            Array nums = Enum.GetValues(typeof(CategoryType));
            foreach (var item in nums)
            {
                Console.WriteLine(Array.IndexOf(nums, item) + " - " + item);
            }
            Console.WriteLine("----------------------------------------------------------");


            // -------------------------------------- ASSIGN CATEGORY ------------------------------------------

            Console.Write("Məhsulun kateqoriyası: ");
            string category = Console.ReadLine();

            CategoryType ctgr;
            while (!Enum.TryParse(category, out ctgr) || !Enum.IsDefined(typeof(CategoryType), ctgr))
            {
                Console.WriteLine($"\"{category}\" adlı kateqoriya mövcud deyil. Yenidən cəhd edin.");
                Console.Write("Məhsulun kateqoriyası: ");
                category = Console.ReadLine();
            }
            return ctgr;
        }

        #endregion

        // =========================== SALE METHODS ===============================
        #region Sale

        /// <summary>
        /// Creates Sale, adds Sale Items untill click SpaceBar button
        /// </summary>
        public void AddSale()
        {
            Sale sale = new Sale();
            sale.SaleNo = SaleId++;
            sale.SaleItems = new List<SaleItem>();
            ConsoleKeyInfo key = default(ConsoleKeyInfo);
            int i = 1;
            do
            {
                SaleItem item = new SaleItem();

                // --------------- input PRODUCT CODE -------------------

                Console.Write($"\n{i} Məhsulun kodu: ");
                string prodCode = Console.ReadLine();
                Product saledProd = Products.Find(p => p.ProductCode == prodCode);
                if (saledProd != null)
                {
                    // --------------- input SALE İTEM COUNT -------------------

                    Console.Write("Məhsulun sayı: ");
                    string ItemCount = Console.ReadLine();
                    int SaleItemCount = To<int>(ItemCount);

                    // --------------- CHECK COUNT IS ZERO OR NOT -------------------

                    while (SaleItemCount == 0)
                    {
                        Console.Write("Məhsulun sayı 0 ola bilməz. Yenidən daxil edin: ");
                        ItemCount = Console.ReadLine();
                        SaleItemCount = To<int>(ItemCount);
                    }

                    // --------------- ASSIGN SALE ITEM DATA -------------------

                    item.No = i;
                    item.product = saledProd;
                    if (saledProd.Quantity == 0)
                    {
                        Console.WriteLine($"{prodCode} kodlu məhsul bitib!");
                        continue;
                    }
                    else if (saledProd.Quantity >= SaleItemCount)
                    {
                        item.prodCount = SaleItemCount;
                        saledProd.Quantity -= SaleItemCount;
                        i++;
                        sale.Amount += saledProd.Price * item.prodCount;
                        sale.SaleItems.Add(item);
                        Console.WriteLine(saledProd.Name);
                    }
                    else
                    {
                        // -----------------------------------> ASKS USER IF WANTS TO BUY LEFT PRODUCT
                        Console.WriteLine($"Daxil edilən miqdar qədər satış mümkün deyil. Mövcud məhsul sayı: {saledProd.Quantity} qədər satış edilsin mi? ");
                        Console.WriteLine("Təsdiqləmək üçün \"Enter\" düyməsini, əks halda digər istəlinən düyməni klikləyin.");
                        if (Console.ReadKey().Key==ConsoleKey.Enter)
                        {
                            item.prodCount = saledProd.Quantity;
                            saledProd.Quantity = 0;
                            i++;
                            sale.Amount += saledProd.Price * item.prodCount;
                            sale.SaleItems.Add(item);
                            Console.WriteLine(saledProd.Name);
                        }
                        else
                        {
                            Console.WriteLine("\nBu məhsul satılmadı.");
                        }
                    }                    
                }
                else
                {
                    Console.WriteLine($"{prodCode} kodlu məhsul mövcud deyil!");
                    continue;
                }
                Console.WriteLine("Prosesi dayandırmaq üçün \"Sapce\" düyməsini, davam etmək üçün isə digər istənilən düyməni klikləyin.");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Spacebar);

            sale.date = DateTime.Now;

            if (sale.SaleItems.Count > 0)
            {
                Sales.Add(sale);
                showSale(sale.SaleNo.ToString());
                Console.WriteLine("Satış əlavə edildi!");
            }
            else Console.WriteLine("Satış əlavə edilmədi!");
        }

        /// <summary>
        /// Show Sale, including Sale No, Sale Date, Sale Items, Each Saled Product count, Prices, Amount
        /// </summary>
        /// <param name="SaleNo">Sale Number</param>
        public void showSale(string SaleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == SaleNo);
            try
            {
                if (sale != null)
                {
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
                        table.AddRow("Date: ", sale.date, "", "", "Sale No:", sale.SaleNo);

                        table.Write((Format.Minimal));

                    }
                    else Console.WriteLine("Satış siyahısı boşdur!");
                }
                else throw new SaleNoException(SaleNo);
            }
            catch (SaleNoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Decrease Sale Item Count by given Count
        /// </summary>
        /// <param name="saleNo">Sale number</param>
        public void DeleteSaleItem(string saleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == saleNo);
            if (sale != null)
            {
                // ---------------------------  Input ItemNo To delete SaleItem -----------------------

                Console.Write("Çıxarılacaq məhsulun nömrəsi: ");
                string prodNo = Console.ReadLine();
                int No = To<int>(prodNo);
                SaleItem item = sale.SaleItems.Find(s => s.No == No);
                if (item != null)
                {
                    // ---------------------------  Input Count To delete SaleItem -----------------------

                    Console.Write("Çıxarılacaq məhsulun sayı: ");
                    string count = Console.ReadLine();
                    int delProdCount = To<int>(count);

                    if (delProdCount <= item.prodCount && delProdCount!=0)
                    {
                        item.prodCount -= delProdCount;
                        Products.Find(p => p.ProductCode == item.product.ProductCode).Quantity += delProdCount;

                        if (item.prodCount == 0)
                        {
                            sale.SaleItems.Remove(item);
                        }

                        Console.WriteLine("Məhsul satışdan silindi.");
                        showSale(saleNo);
                    }
                    else if (delProdCount == 0) Console.WriteLine("Daxil edilən say 0-dır. Məhsul silinmədi.");
                    else Console.WriteLine($"{count} miqdardan az satılıb.");
                }
                else Console.WriteLine("Məhsul nömrəsi düzgün daxil edilməyib!");
            }
            else throw new SaleNoException();
        }

        /// <summary>
        /// Delete Sale from Sale List
        /// </summary>
        /// <param name="saleNo">Sale number</param>
        public void DeleteSale(string saleNo)
        {
            Sale sale = Sales.Find(s => s.SaleNo.ToString() == saleNo);
            if (sale != null)
            {
                List<SaleItem> saleItems = sale.SaleItems;
                foreach (SaleItem item in saleItems)
                {
                    Products.Find(p => p.ProductCode == item.product.ProductCode).Quantity += item.prodCount;
                }
                Sales.Remove(sale);
            }
            else throw new SaleNoException(saleNo);
        }

        /// <summary>
        /// Finds Sales by given Amount range
        /// </summary>
        /// <param name="mnAmount">Minimum amount</param>
        /// <param name="mxAmount">Maximum amount</param>
        /// <returns>Sale list by Amount range</returns>
        public List<Sale> GetSalesByAmountRange(double mnAmount, double mxAmount)
        {
            return Sales.FindAll(s => s.Amount >= mnAmount && s.Amount <= mxAmount);
        }

        /// <summary>
        /// Finds Sales between two date
        /// </summary>
        /// <param name="startDate">First Sale date</param>
        /// <param name="endDate">Last Sale date</param>
        /// <returns>Sale list by Date range</returns>
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return Sales.FindAll(s => s.date.Date >= startDate.Date && s.date.Date <= endDate.Date);
        }

        /// <summary>
        /// Finds Sales by given Date
        /// </summary>
        /// <param name="day">Sale Date</param>
        /// <returns>Sale list by date</returns>
        public List<Sale> GetSalesByDay(DateTime day)
        {
            return Sales.FindAll(s => s.date.Date == day.Date);
        }

        /// <summary>
        /// Finds Sale by given Sale number
        /// </summary>
        /// <param name="SaleNo">Sale number</param>
        /// <returns>Sale by SaleNo</returns>
        public Sale GetSalesBySaleNo(string SaleNo)
        {
            return Sales.Find(s => s.SaleNo.ToString() == SaleNo);
        }

        /// <summary>
        /// Show Sales by given Sale List
        /// </summary>
        /// <param name="sales">Sale List</param>
        public void ShowSales(List<Sale> sales)
        {
            if (sales.Count > 0)
            {
                var table = new ConsoleTable("No","Sale No", "Məhsul sayı", "Məbləğ", "Tarix");
                int i = 1;
                foreach (Sale item in sales)
                {
                    table.AddRow(i, item.SaleNo, item.SaleItems.Count, item.Amount.ToString("0.00"), item.date);
                    i++;
                }
                table.Write();
            }
            else Console.WriteLine("Satış siyahısı boşdur.");
        }
        #endregion
    }
}
