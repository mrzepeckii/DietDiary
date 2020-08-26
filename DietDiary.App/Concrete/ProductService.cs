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

        //  public List<Product> Products;

        /*  public ProductService()
          {
              Products = new List<Product>();
          }*/

        /*public ConsoleKeyInfo ProductsView(MenuActionService actionService)
        {
            var productsView = actionService.GetMenuActionsByMenuName("ProductsMenu");
            Console.WriteLine();
            for (int i = 0; i < productsView.Count; i++)
                Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");

            var chosenOption = Console.ReadKey();
            return chosenOption;
        }*/

        /*   public int AddNewProduct(int category, int calorific, string name, double proteins, double carbos, double fats)
           {
               Product product = new Product
               {
                   Id = Products.Count + 1,
                   Category = category,
                   Calorific = calorific,
                   Name = name,
                   Proteins = proteins,
                   Carbos = carbos,
                   Fats = fats
               };
               Products.Add(product);
               return product.Id;
           }*/

        /*   public Product FindProductById(int productId)
           {
               Product tempProduct = new Product();
               foreach (var item in Products)
                   if (item.Id == productId)
                   {
                       tempProduct = item;
                       break;
                   }       
               return tempProduct;
           }*/

        /* public Product FindProductByName(string name)
         {
             Product tempProduct = new Product();
             foreach (var item in Products)
                 if (item.Name == name)
                     tempProduct = item;
             return tempProduct;
         }*/

        /*  public void ListOfProductsView(char productCategory)
          {
              int productCategoryId;
              Int32.TryParse(productCategory.ToString(), out productCategoryId);
              foreach (var item in Products)
                  if(item.Category == productCategoryId)
                          Console.WriteLine($"\n{item.Name}");
          }*/

        /*   public void ListOfProductsView()
           {
               foreach (var item in Products)
                       Console.WriteLine($"\n{item.Id}.{item.Name}");
           }*/
    }
}
