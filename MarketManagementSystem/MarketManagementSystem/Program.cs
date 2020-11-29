using System;
using System.Collections.Generic;
using System.Text;
using MarketManagementSystem.Infrastructure.Enums;
using MarketManagementSystem.Infrastructure.Models;
using MarketManagementSystem.Infrastructure.Services;

namespace MarketManagementSystem
{
    class Program
    {
        static Marketable operations = new Marketable();
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

        #region Check Is Date
        public static DateTime ToDate(string value)
        {
            bool converted = false;
            DateTime date = default(DateTime);
            while (!converted)
            {
                try
                {
                    date = (DateTime)Convert.ChangeType(value, typeof(DateTime));
                    converted = true;
                }
                catch
                {
                    converted = false;
                    Console.WriteLine("Tarixi düzgün daxil etmədiniz. Yenidən cəhd edin!");
                    Console.Write("Tarix (gün.ay.il) : ");
                    value = Console.ReadLine();
                }
            }
            return date;
        }

        #endregion

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
            Console.WriteLine("- 1 Məhsullar üzərində əməliyyat aparmaq\n" +
                              "- 2 Satışlar üzərində əməliyyat aparmaq\n" +
                              "- 3 Sistemdən çıxmaq");
            int SelectInt;

            do
            {
                Console.Write("Seçiminiz: ");
                string select = Console.ReadLine();
                while (!int.TryParse(select, out SelectInt))
                {
                    Console.WriteLine("Rəqəm daxil edin.");
                    Console.Write("Seçiminiz: ");
                    select = Console.ReadLine();
                }
                switch (SelectInt)
                {
                    case 1:
                        Console.WriteLine("---------------- Məhsullar üzərində əməliyyatlar ----------------");
                        showProductChoices();
                        ProductOperations();
                        break;
                    case 2:
                        Console.WriteLine("---------------- Satışlar üzərində əməliyyatlar -----------------");
                        showSaleChoices();
                        SaleOperations();
                        break;
                    case 3:
                        Console.WriteLine("Sistemdən çıxış etdiniz.");
                        break;
                    default:
                        Console.WriteLine("Əməliyyat aparmaq üçün 1 - 3 intervalında rəqəm daxil edə bilərsiniz.");
                        continue;
                }


            } while (SelectInt != 3);

        }


        #region Product operations
        static void ProductOperations()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int SlctInt;
            do
            {
                Console.Write("Seçiminiz: ");
                string slct = Console.ReadLine();
                while (!int.TryParse(slct, out SlctInt))
                {
                    Console.WriteLine("Rəqəm daxil edin.");
                    slct = Console.ReadLine();
                }
                switch (SlctInt)
                {
                    case 0:
                        Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
                        Console.WriteLine("- 1 Məhsullar üzərində əməliyyat aparmaq\n" +
                                          "- 2 Satışlar üzərində əməliyyat aparmaq\n" +
                                          "- 3 Sistemdən çıxmaq");
                        break;
                    case 1:
                        Console.WriteLine("---- Yeni məhsul əlavə edilməsi ----");
                        AddProduct();
                        break;
                    case 2:
                        Console.WriteLine("-- Məhsul məlumatlarına düzəliş edilməsi --");
                        EditProduct();
                        break;
                    case 3:
                        Console.WriteLine("------ Məhsulun silinməsi ------");
                        DeleteProduct();
                        break;
                    case 4:
                        Console.WriteLine("-------------- Bütün məhsullar --------------");
                        operations.ShowProducts(operations.Products);
                        showProductChoices();
                        break;
                    case 5:
                        Console.WriteLine("-------------- Kateqoriyasına görə məhsullar --------------");
                        showProductsByCategory();
                        break;
                    case 6:
                        Console.WriteLine("------------------ Qiymət aralığına görə məhsullar ------------------");
                        showProductsByPriceRange();
                        break;
                    case 7:
                        Console.WriteLine("------------------ Məhsullar arasında ada görə axtarış ------------------");
                        showProductByName();
                        break;
                    default:
                        Console.WriteLine("Əməliyyat aparmaq üçün 0 - 7 intervalında rəqəm daxil edə bilərsiniz.");
                        break;
                }
            } while (SlctInt != 0);

        }

        static void showProductChoices()
        {
            Console.WriteLine("");
            Console.WriteLine("Məhsullar üzərində əməliyyat aparmaq üçün 0-7 intervalında rəqəm daxil edin: ");
            Console.WriteLine(" 1 - Yeni məhsul əlavə edilməsi\n" +
                              " 2 - Məhsul üzərində düzəliş edilməsi\n" +
                              " 3 - Məhsulun silinməsi\n" +
                              " 4 - Bütün məhsulların göstərilməsi\n" +
                              " 5 - Kateqoriyasına görə məhsulların göstərilməsi\n" +
                              " 6 - Qiymət aralığına görə məhsulların göstərilməsi\n" +
                              " 7 - Məhsullar arasında ada görə axtarış\n" +
                              " 0 - Məhsullar üzrə əməliyyatlardan çıxış");
            Console.WriteLine("");
        }
        static void AddProduct()
        {
            Console.OutputEncoding = Encoding.UTF8;
            operations.AddProduct();
            Console.WriteLine("\n Məhsul əlavə edildi. ");
            showProductChoices();
        }
        static void EditProduct()
        {
            Console.Write("Düzəliş etmək istədiyiniz məhsul kodunu daxil edin: ");
            string prodCode = Console.ReadLine();
            operations.EditProdInfo(prodCode);
            showProductChoices();
        }
        static void DeleteProduct()
        {
            Console.Write("Silmək istədiyiniz məhsul kodunu daxil edin: ");
            string prodCode = Console.ReadLine();
            operations.DeleteProduct(prodCode);
            showProductChoices();
        }
        static void showProductsByCategory()
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

            // --------------------------------------  ASSIGN CATEGORY ---------------------------------------

            Console.Write("Kateqoriyanı daxil edin: ");
            string category = Console.ReadLine();
            operations.GetProductByCategory(category);
            showProductChoices();
        }
        static void showProductsByPriceRange()
        {
            Console.Write("Minimum qiymət: ");
            string minPrice = Console.ReadLine();

            Console.Write("Maksimum qiymət: ");
            string maxPrice=Console.ReadLine();
            operations.GetProductByPriceRange(minPrice, maxPrice);
            showProductChoices();
        }
        static void showProductByName()
        {
            Console.Write("Məhsulun adı: ");
            string name = Console.ReadLine();
            List<Product> products = operations.GetProductByName(name);
            if (products.Count != 0)
            {
                operations.ShowProducts(products);
            }
            else Console.WriteLine($"{name} adlı məhsul mövcud deyil.");
            showProductChoices();
        }
        #endregion

        #region Sale operations
        static void SaleOperations()
        {
            int SlctInt;
            do
            {
                Console.Write("Seçiminiz: ");
                string slct = Console.ReadLine();
                Console.WriteLine("");
                while (!int.TryParse(slct, out SlctInt))
                {
                    Console.WriteLine("Rəqəm daxil edin.");
                    Console.Write("Seçiminiz: ");
                    slct = Console.ReadLine();
                }
                switch (SlctInt)
                {
                    case 0:
                        Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
                        Console.WriteLine("- 1 Məhsullar üzərində əməliyyat aparmaq\n" +
                                          "- 2 Satışlar üzərində əməliyyat aparmaq\n" +
                                          "- 3 Sistemdən çıxmaq");
                        break;
                    case 1:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n-----------------------  SATIŞ ƏLAVƏ ET ------------------------");
                        addSale();
                        break;
                    case 2:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n----------------------- MƏHSULUN GERİ QAYTARILMASI -----------------------");
                        deleteSaleItem();
                        break;
                    case 3:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n----------------------- SATIŞIN SİLİNMƏSİ -----------------------");
                        deleteSale();
                        break;
                    case 4:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n----------------------- BÜTÜN SATIŞLAR -----------------------");
                        operations.ShowSales(operations.Sales);
                        showSaleChoices();
                        break;
                    case 5:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n--------------------- SEÇİLMİŞ TARİX ARALIĞINA GÖRƏ SATIŞLAR --------------------");
                        ShowSalesByDateRange();
                        break;
                    case 6:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("--------------------- SEÇİLMİŞ MƏBLƏĞ ARALIĞINA GÖRƏ SATIŞLAR ----------------------");
                        ShowSalesByAmountRange();
                        break;
                    case 7:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n----------------------- SEÇİLMİŞ TARİXƏ GÖRƏ SATIŞLAR -----------------------");
                        ShowSalesByDay();
                        break;
                    case 8:
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("\n-------------- SATIŞ NÖMRƏSİNƏ GÖRƏ SATIŞ MƏLUMATLARININ ÇIXARILMASI --------------");
                        Console.Write("Satış nömrəsi: ");
                        string saleNo = Console.ReadLine();
                        operations.showSale(saleNo);
                        showSaleChoices();
                        break;
                    default:
                        Console.WriteLine("Əməliyyat aparmaq üçün 1 - 8 intervalında rəqəm daxil edə bilərsiniz.");
                        break;
                }


            } while (SlctInt != 0);

        }
        static void showSaleChoices()
        {
            Console.WriteLine("");
            Console.WriteLine("- 1 Yeni satış əlavə etmək\n" +
                              "- 2 Satışdakı məhsulun geri qaytarılması\n" +
                              "- 3 Satışın silinməsi \n" +
                              "- 4 Bütün satışların ekrana çıxarılması\n" +
                              "- 5 Verilən tarix aralığına görə satışların göstərilməsi\n" +
                              "- 6 Verilən məbləğ aralığına görə satışların göstərilməsi\n" +
                              "- 7 Verilmiş bir tarixdə olan satışların göstərilməsi\n" +
                              "- 8 Verilmiş nömrəyə əsasən həmin nömrəli satışın məlumatlarının göstərilməsi");
            Console.WriteLine("");
        }
        static void addSale()
        {
            operations.AddSale();
            Console.WriteLine("==========================================================================================");
            showSaleChoices();
        }
        static void deleteSale()
        {
            Console.Write("Satış nömrəsini daxil edin: ");
            string saleNo = Console.ReadLine();
            operations.DeleteSale(saleNo);
            showSaleChoices();
        }
        static void deleteSaleItem()
        {
            Console.Write("Satış nömrəsi: ");
            string saleNo = Console.ReadLine();
            operations.DeleteSaleItem(saleNo);
            Console.WriteLine("==========================================================================================");
            showSaleChoices();
        }
        static void ShowSalesByAmountRange()
        {
            List<Sale> sales;
            Console.Write("Minimum məbləğ: ");

            string amountMin = Console.ReadLine();
            double mnAmount = To<double>(amountMin);

            Console.Write("Maksimum məbləğ: ");
            string amountMax = Console.ReadLine();
            double mxAmount = To<double>(amountMax);

            if (mnAmount < mxAmount)
            {
                sales = operations.GetSalesByAmountRange(mnAmount, mxAmount);
            }
            else
            {
                sales = null;
                Console.WriteLine("Intervalı düzgün daxil etməmisiniz.");
            }

            if (sales != null)
            {
                operations.ShowSales(sales);
            }
            else Console.WriteLine("Bu məbləğ aralığında satış tapılmadı.");
            showSaleChoices();

        }
        static void ShowSalesByDateRange()
        {
            Console.Write("Başlanğıc tarix (ay.gün.il): ");
            string startDate = Console.ReadLine();
            DateTime dateSt = ToDate(startDate);

            Console.Write("Son tarix (ay.gün.il): ");
            string endDate = Console.ReadLine();
            DateTime dateEnd = ToDate(endDate);

            List<Sale> sales = operations.GetSalesByDateRange(dateSt, dateEnd);
            operations.ShowSales(sales);
            showSaleChoices();
        }
        static void ShowSalesByDay()
        {
            Console.Write("Tarix: (gün.ay.il) ");
            string dt = Console.ReadLine();
            DateTime date = ToDate(dt);
            List<Sale> sales = operations.GetSalesByDay(date);
            operations.ShowSales(sales);
            Console.WriteLine(date);
            showSaleChoices();
        }
        #endregion



    }
}
