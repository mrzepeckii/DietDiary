using DietDiary.App.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class ProductService : BaseService<Product>
    {
        public ProductService()
        {

        }
        public ProductService(string path)
        {
           Items = ReadItemsFromXml("Products", path).ToList();
        }
        public void ProductDetails(Product product)
        {
            Console.WriteLine($"\nNazwa - {product.Name}");
            Console.WriteLine($"Kaloryczność w 100 gramach - {product.Calorific}");
            Console.WriteLine($"Węglowodany w 100 gramach - {product.Carbos}");
            Console.WriteLine($"Białko w 100 gramach - {product.Proteins}");
            Console.WriteLine($"Tłuszcze w 100 gramach - {product.Fats}\n");
        }

        public Product UpdateNutrionalValues(Product product, int calorific, double carbos, double proteins, double fats)
        {
            product.Calorific = calorific;
            product.Carbos = carbos;
            product.Proteins = proteins;
            product.Fats = fats;
            return product;
        }
    }
}
