using System;
using System.Text;
using MarketManagementSystem.Infrastructure.Services;

namespace MarketManagementSystem
{
    class Program
    {
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
            Marketable operations = new Marketable();
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
                        Console.WriteLine("frst");
                        break;
                    case 2:
                        Console.WriteLine("2fdg");
                        break;
                    case 3:
                        Console.WriteLine("3fdg");
                        break;
                    case 4:
                        Console.WriteLine("4fdg");
                        break;
                    case 5:
                        Console.WriteLine("5fdg");
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

    }
}
/* 
 1.
   ekrana 3 secim cixir
    -1 Mehsullar uzerinde emeliyyat aparmaq
    -2 Satislar uzerinde emeliyyat aparmaq
    -3 Sistemden cixmaq
	
1.1 1 secildikde Mehsullar uzerinde aparila bilinecek emeliyyatlarla bagli secimler gosterilir:
    
    - 1 Yeni mehsul elave et  - userden yeni mehsul yaradilmasi ucun lazim olan melumatlari daxil edilmelidir
    - 2 Mehsul uzerinde duzelis et -  duzelis edilecek mehsulun code-u ve duzelis melumatlari daxil edilmelidir
    - 3 Mehsulu sil - mehsulu kodu daxil edilmelidir
    - 4 Butun mehsullari goster - butun mehsullar gosterilecek (kodu,adi,categoriyasi,sayi,qiymeti)
    - 5 Categoriyasina gore mehsullari goster - usere var olan kateqoriyalar gosteilecek ve onlar arasinda bir secim etmelidir ve secilmis kateqoriyadan olan butun mehsullar gosterilir (kodu,adi,categoriyasi,sayi,qiymeti)
    - 6 Qiymet araligina gore mehsullari goster - userden minmum ve maximum qiymetleri daxil etmesi istenilir ve hemin qiymet araliginda olan mehsullar gosterilir (kodu, adi,categoriyasi,sayi,qiymeti)
    - 7 Mehsullar arasinda ada gore axtaris et - useden text daxil etmesi istenilir ve adinda hemin text olan butun mehsullar gosterilir (kodu, adi,categoriyasi,sayi,qiymeti)
 */