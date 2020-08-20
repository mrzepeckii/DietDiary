using DietDiary.App.Abstract;
using DietDiary.App.Concrete;
using DietDiary.Domain.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietDiary.App.Managers
{
    public class ProductManager
    {
        private readonly MenuActionService _actionService;
        private IService<Product> _productService;

        public ProductManager(IService<Product> productService, MenuActionService actionService)
        {
            _productService = productService;
            _actionService = actionService;
        }

        public void ChoseOptionInProductMenu()
        {
            
            while (true)
            {
                Console.Clear();
                var productsView = _actionService.GetMenuActionsByMenuName("ProductsMenu");
                Console.WriteLine();
                for (int i = 0; i < productsView.Count; i++)
                {
                    Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");
                }

                var chosenOption = Console.ReadKey();
                if (chosenOption.KeyChar == '0')
                {
                    break;
                }
                switch (chosenOption.KeyChar)
                {
                    case '1':
                        ItemView();
                        break;
                    case '2':
                        var id = AddNewProduct();
                        break;
                    case '3':
                        RemoveItemById();
                        break;
                    default:
                        break;
                }
            }
        }
        public int AddNewProduct()
        {
            Console.Clear();
            var productsView = _actionService.GetMenuActionsByMenuName("ProductsCategory");
            Console.WriteLine();
            for (int i = 0; i < productsView.Count; i++)
                Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");

            var category = Console.ReadKey();
            int numberOfCate, calorific;
            double carbos, fats, proteins;
            Int32.TryParse(category.KeyChar.ToString(), out numberOfCate);
            if (numberOfCate == 0)
            {
                return 0;
            }
            Console.WriteLine("\nWprowadź nazwę produktu: ");
            string nameOfProduct = Console.ReadLine();
            Console.WriteLine("\nWprowadź ilość kalorii: ");
            while (!Int32.TryParse(Console.ReadLine(), out calorific))
            {
                Console.WriteLine("Podaj kalorie w postaci liczby całkowitej");
            }
            Console.WriteLine("\nWprowadź zawartość węglowodanów: ");
            while (!double.TryParse(Console.ReadLine(), out carbos))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            Console.WriteLine("\nWprowadź zawartość białka: ");
            while (!double.TryParse(Console.ReadLine(), out proteins))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            Console.WriteLine("\nWprowadź zawartość tłuszczy: ");
            while (!double.TryParse(Console.ReadLine(), out fats))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            var id = _productService.GetLastId();
            Product product = new Product(id + 1, numberOfCate, nameOfProduct, calorific, proteins, carbos, fats);
            _productService.AddItem(product);

            return product.Id;
        }

        public void ItemView()
        {
            Console.Clear();
            List<Product> products = _productService.GetAllItems();
            if (products.Any())
            {
                foreach (var product in _productService.GetAllItems())
                {
                    Console.WriteLine($"{product.Id}. {product.Name}");
                }
                Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nAktualnie brak produktów - dodaj produkt do bazy.");
                Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                Console.ReadKey();
            }
           
        }

        public void RemoveItemById()
        {
            Console.Clear();
            int id;
            Console.WriteLine("Wybierz produkt z listy: ");
            ItemView();
            var tempId = Console.ReadLine();
            Int32.TryParse(tempId, out id);
            var item = _productService.GetItemById(id);
            if (item != null)
            {
                _productService.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("Nie ma takiego produktu");
            }

        }
    }
}
