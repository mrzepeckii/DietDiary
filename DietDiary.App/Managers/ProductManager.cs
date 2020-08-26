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
        private ProductService _productService;

        public ProductManager(ProductService productService, MenuActionService actionService)
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
                        ItemsView(true);
                        GoToMenuView();
                        break;
                    case '2':
                        var category = ChoseCategoryOfProductView();
                        ItemsView(category);
                        GoToMenuView();
                        break;
                    case '3':
                        var idToDetail = ChoseItemView();
                        var itemToShow = _productService.GetItemById(idToDetail);
                        _productService.ProductDetails(itemToShow);
                        GoToMenuView();
                        break;
                    case '4':
                        var id = AddNewProduct();
                        break;
                    case '6':
                        var idToRemove = ChoseItemView();
                        RemoveItemById(idToRemove);
                        break;
                    default:
                        break;
                }
            }
        }
        private int AddNewProduct()
        {
            var productToAdd = AskUserAboutCalorificProductView();
            var category = ChoseCategoryOfProductView();
            productToAdd.Category = category;
            var id = _productService.GetLastId();
            _productService.AddItem(productToAdd);

            return productToAdd.Id;
        }



        private void ItemsView(int category)
        {
           
            List<Product> products = _productService.GetAllItems().Where(p => p.Category == category).ToList();
            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name}");
                }
                   /* Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                    Console.ReadKey();*/
            }
            else
            {
                Console.WriteLine($"\nAktualnie brak produktów z danej kateogrii - dodaj produkt do bazy.");
               /* Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                Console.ReadKey();*/
            }
        }

        private void GoToMenuView()
        {
            Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
            Console.ReadKey();
        }
        private void ItemsView(bool viewInMenu)
        {
            if (viewInMenu)
            {
                Console.Clear();
            }
            List<Product> products = _productService.GetAllItems();
            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name}");
                }
               /* if (viewInMenu)
                {
                    Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                    Console.ReadKey();
                } */
            }
            else
            {
                Console.WriteLine($"\nAktualnie brak produktów - dodaj produkt do bazy.");
              /*  Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
                Console.ReadKey();*/
            }  
        }

        private int ChoseItemView()
        {
            Console.Clear();
            int id;
            Console.WriteLine("Wybierz produkt z listy: ");
            ItemsView(false);
            var tempId = Console.ReadLine();
            Int32.TryParse(tempId, out id);
            return id;
        }


        public void RemoveItemById(int id)
        {
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

        private int ChoseCategoryOfProductView()
        {
            Console.Clear();
            int category;
            var productsView = _actionService.GetMenuActionsByMenuName("ProductsCategory");
            Console.WriteLine();
            for (int i = 0; i < productsView.Count; i++)
                Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");
            while (!Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out category))
            {
                Console.WriteLine("Podaj kalorie w postaci liczby całkowitej");
            }
            return category;
        }

        private Product AskUserAboutCalorificProductView()
        {
            int calorific;
            double carbos, fats, proteins;
            Console.WriteLine("\nWprowadź nazwę produktu: ");
            string nameOfProduct = Console.ReadLine();
            Console.WriteLine("\nWprowadź ilość kalorii w 100 gramach: ");
            while (!Int32.TryParse(Console.ReadLine(), out calorific))
            {
                Console.WriteLine("Podaj kalorie w postaci liczby całkowitej");
            }
            Console.WriteLine("\nWprowadź zawartość węglowodanów w 100 gramach: ");
            while (!double.TryParse(Console.ReadLine(), out carbos))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            Console.WriteLine("\nWprowadź zawartość białka w 100 gramach: ");
            while (!double.TryParse(Console.ReadLine(), out proteins))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            Console.WriteLine("\nWprowadź zawartość tłuszczy w 100 gramach: ");
            while (!double.TryParse(Console.ReadLine(), out fats))
            {
                Console.WriteLine("Podaj zawartość w postaci liczby");
            }
            Product product = new Product { Name = nameOfProduct };
            _productService.UpdateNutrionalValues(product, calorific, carbos, proteins, fats);
            return product;
        }


    }
}
