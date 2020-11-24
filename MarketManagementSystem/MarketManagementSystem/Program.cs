using System;
using System.Text;
using MarketManagementSystem.Infrastructure.Services;

namespace MarketManagementSystem
{
    class Program
    {
        static Marketable operations = new Marketable();

        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
            Console.WriteLine("- 1 Məhsullar üzərində əməliyyat aparmaq\n" +
                "- 2 Satışlar üzərində əməliyyat aparmaq\n" +
                "- 3 Sistemdən çıxmaq");
            int SelectInt;

            do
            {
                string select = Console.ReadLine();
                while (!int.TryParse(select, out SelectInt))
                {
                    Console.WriteLine("Reqem daxil etmelisinz.");
                    select = Console.ReadLine();
                }
                switch (SelectInt)
                {
                    case 1:
                        Console.WriteLine("---------------- Məhsullar üzərində əməliyyatlar ----------------");
                        Console.WriteLine(" 1 - Yeni mehsul elave et\n" +
                            " 2 - Mehsul uzerinde duzelis et\n" +
                            " 3 - Mehsulu sil\n" +
                            " 4 - Butun mehsullari goster\n" +
                            " 5 - Categoriyasina gore mehsullari goster\n" +
                            " 6 - Qiymet araligina gore mehsullari goster\n" +
                            " 7 - Mehsullar arasinda ada gore axtaris et\n" +
                            " 0 - Məhsullar üzrə əməliyyatlardan çıxış");
                        Console.WriteLine("Məhsullar üzərində əməliyyat aparmaq üçün 0-7 intervalında rəqəm daxil edin: ");
                        ProductOperations();
                        break;
                    case 2:
                        Console.WriteLine("---------- Satışlar üzərində əməliyyatlar ----------");
                        Console.WriteLine("- 1 Yeni satis elave etmek\n" +
                            "- 2 Satisdaki hansisa mehsulun geri qaytarilmasi\n" +
                            "- 3 Satisin silinmesi - satisin nomresine esasen silinmesi\n" +
                            "- 4 Butun satislarin ekrana cixarilmasi\n" +
                            "- 5 Verilen tarix araligina gore satislarin gosterilmesi\n" +
                            "- 6 Verilen mebleg araligina gore satislarin gosterilmesi\n" +
                            "- 7 Verilmis bir tarixde olan satislarin gosterilmesi\n" +
                            "- 8 Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
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
        
        public static void ProductOperations()
        {
            int SlctInt;
            do
            {
                string slct = Console.ReadLine();
                while (!int.TryParse(slct, out SlctInt))
                {
                    Console.WriteLine("Reqem daxil etmelisinz.");
                    slct = Console.ReadLine();
                }
                switch (SlctInt)
                {
                    case 0:
                        Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
                        Console.WriteLine("- 1 Mehsullar uzerinde emeliyyat aparmaq\n" +
                            "- 2 Satislar uzerinde emeliyyat aparmaq\n" +
                            "- 3 Sistemden cixmaq");
                        continue;
                    case 1:
                        Console.WriteLine("-- Yeni mehsul elave et --");
                        operations.AddProduct();
                        break;
                    case 2:
                        Console.WriteLine("-- Məhsul məlumatlarına düzəliş et --");
                        operations.EditProdInfo();
                        break; 
                    case 3:
                        Console.WriteLine("------ Mehsulu sil ------");
                        operations.DeleteProduct();
                        break; 
                    case 4:
                        Console.WriteLine("------ Bütün məhsullar ------");
                        operations.ShowProducts(operations.Products);
                        break; 
                    case 5:
                        Console.WriteLine("----- Categoriyasina gore mehsullari goster -----");
                        operations.GetProductByCategory();
                        break; 
                    case 6:
                        Console.WriteLine("---- Qiymet araligina gore mehsullari goster ----");
                        operations.GetProductByPriceRange();
                        break; 
                    case 7:
                        Console.WriteLine("---- Mehsullar arasinda ada gore axtaris et ----");
                        operations.GetProductByName();
                        break;
                    default:
                        Console.WriteLine("Əməliyyat aparmaq üçün 0 - 7 intervalında rəqəm daxil edə bilərsiniz.");
                        break;
                }
            } while (SlctInt != 0);

           
            
        }
        public static void SaleOperations()
        {
            int SlctInt;
            do
            {
                string slct = Console.ReadLine();
                while (!int.TryParse(slct, out SlctInt))
                {
                    Console.WriteLine("Reqem daxil etmelisinz.");
                    slct = Console.ReadLine();
                }
                switch (SlctInt)
                {
                    case 0:
                        Console.WriteLine("1 - 3 arasında rəqəm daxil edin: ");
                        Console.WriteLine("- 1 Mehsullar uzerinde emeliyyat aparmaq\n" +
                            "- 2 Satislar uzerinde emeliyyat aparmaq\n" +
                            "- 3 Sistemden cixmaq"); 
                        continue;
                    case 1:
                        Console.WriteLine("------- Satış əlavə et -------");
                        addSale();
                        break;
                    case 2:
                        Console.WriteLine("------ Məhsulun geri qaytarılması ------");
                        deleteSaleItem();
                        break;
                    case 3:
                        Console.WriteLine("------ Satışın silinməsi ------");

                        break;
                    case 4:
                        Console.WriteLine("------- BÜTÜN SİFARİŞLƏR -------");
                        operations.ShowSales();
                        break;
                    case 5:
                        Console.WriteLine("------- BÜTÜN SİFARİŞLƏR -------");
                        Console.Write("Sifariş nömrəsi: ");
                        string saleNo=Console.ReadLine();
                        operations.showSale(saleNo);
                        break;
                    case 6:
                        Console.WriteLine("6fdg");
                        break;
                    case 7:
                        Console.WriteLine("7fdg");
                        break;
                    default:
                        Console.WriteLine("Əməliyyat aparmaq üçün 1 - 8 intervalında rəqəm daxil edə bilərsiniz.");
                        break;
                }


            } while (SlctInt != 0);
            
        }

        static void addSale()
        {
            Console.WriteLine("Satışdakı məhsul növlərinin sayını daxil edin: ");
            string prodCount = Console.ReadLine();
            int productCount;
            while (!int.TryParse(prodCount, out productCount))
            {
                Console.WriteLine("Reqem daxil etmelisinz.");
                prodCount = Console.ReadLine();
            }
            operations.AddSale(productCount);
        }
        static void deleteSale()
        {
            Console.WriteLine("Satış nömrəsini daxil edin: ");
            string saleNo = Console.ReadLine();
            operations.DeleteSale(saleNo);
        }
        static void deleteSaleItem()
        {
            Console.WriteLine("Satış nömrəsi: ");
            string saleNo = Console.ReadLine();
            operations.DeleteSaleItem(saleNo);
            operations.showSale(saleNo);
        }
    }
}
/* 
 1.
   ekrana 3 secim cixir
    -1 Mehsullar uzerinde emeliyyat aparmaq
    -2 Satislar uzerinde emeliyyat aparmaq
    -3 Sistemden cixmaq
	

 */