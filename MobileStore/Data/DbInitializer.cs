using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Data
{
    public static class DbInitializer
    {
        public static Dictionary<String, Manufacturer> manufacturers = new Dictionary<String, Manufacturer>()
                {
                    {"Apple",new Manufacturer { Name = "Apple" } },
                    {"Samsung",new Manufacturer { Name = "Samsung" } },
                    {"Xiaomi", new Manufacturer { Name = "Xiaomi" } },
                    {"Huawei",new Manufacturer { Name = "Huawei" } },
                    {"Google",new Manufacturer { Name = "Google" } }
                };

        public static List<ProductImage> images = new List<ProductImage>();

        public static void Init(AppDbContent content)
        {
            if (!content.Manufacturer.Any())
            {
                content.Manufacturer.AddRange(manufacturers.Values);
            }

            if (!content.MobileProduct.Any())
            {
                content.MobileProduct.AddRange(GenerateMobileProducts(30));
            }
            
            content.SaveChanges();

            if (!content.Image.Any())
            {
                foreach (Product prod in content.MobileProduct)
                {
                    images.Add(new ProductImage { ImageUrl = "https://store.pine64.org/wp-content/uploads/2019/09/PinePhone-600x600.png", ProductID=prod.MobileProductID });
                    images.Add(new ProductImage { ImageUrl = "https://www.lg.com/us/images/cell-phones/md07000171/gallery/medium01.jpg", ProductID = prod.MobileProductID });
                    images.Add(new ProductImage { ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/413pD2TNh8L._SX466_.jpg", ProductID = prod.MobileProductID });
                }
                content.Image.AddRange(images);
            }
            content.SaveChanges();
        }

        public static IEnumerable<Product> GenerateMobileProducts(int qtt)
        {
            List<Product> tmpList = new List<Product>();

            string[] names = new string[] {
                "Pixel", "Mi10", "Hakuna2002", "IphoneL","IphoneM",
                "IphoneXL", "IphoneXXL","P20", "P1001", "ExpressMusic"
            };

            string[] OsVersions = new string[] {
                "AndroidRedLabel","AndroidVegan","AndroidDiabet","IOS4Putin","Gooose",
                "WinHaha64","JssoS"
            };

            List<Manufacturer> manufacts = Enumerable.ToList(manufacturers.Values);

            for (int i = 0; i < qtt; i++)
            {
                Random rnd = new Random();
                tmpList.Add(new Product
                {
                    Name = names[rnd.Next(0, names.Count() - 1)],
                    OS = OsVersions[rnd.Next(0, OsVersions.Count() - 1)],
                    Size = "2x3",
                    Weight = 150,
                    Screen = "LCD",
                    VideoUrl = "https://www.youtube.com/embed/uyU5rdJcd8U",
                    Manufacturer = manufacts[rnd.Next(0, manufacts.Count() - 1)],
                    Price = rnd.Next(1, 100),
                    CPU = "AngryDragon2.0",
                    RAM = 32
                });
            }
            return tmpList;
        }
    }
}
