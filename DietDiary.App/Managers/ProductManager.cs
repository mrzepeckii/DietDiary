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
                productsView.ForEach(pV => Console.WriteLine($"{pV.Id}. {pV.Name}"));
             //   for (int i = 0; i < productsView.Count; i++)
               // {
                 //   Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");
                //}
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
                        ProductDetailView();
                        GoToMenuView();
                        break;
                    case '4':
                        var id = AddNewProduct();
                        break;
                    case '5':
                        var productToUpdate = ProductDetailView();
                        if(productToUpdate != null)
                        {
                            AskUserAboutCalorificProductView(productToUpdate);
                        }
                        GoToMenuView();
                        break;
                    case '6':
                        var idToRemove = ChoseItemView();
                        if(idToRemove != 0)
                        {
                            RemoveItemById(idToRemove);
                        }                  
                        GoToMenuView();
                        break;
                    default:
                        break;
                }
            }
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

        private int AddNewProduct()
        {
            var id = _productService.GetLastId();
            Product productToAdd = new Product() { Id = id+1 };
            var category = ChoseCategoryOfProductView();
            if(category == 0) { return 0; }
            productToAdd.Category = category;
            AskUserAboutCalorificProductView(productToAdd);
            _productService.AddItem(productToAdd);

            return productToAdd.Id;
        }

        private Product AskUserAboutCalorificProductView(Product product)
        {
            Console.Clear();
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
            product.Name = nameOfProduct;
            _productService.UpdateNutrionalValues(product, calorific, carbos, proteins, fats);
            return product;
        }

        private Product ProductDetailView()
        {
            var idToDetail = ChoseItemView();
            var itemToShow = _productService.GetItemById(idToDetail);
            if(itemToShow != null)
            {
                _productService.ProductDetails(itemToShow);
            }
            return itemToShow;
        }

        private void ItemsView(int category)
        {
            Console.Clear();
            List<Product> products = _productService.GetAllItems().Where(p => p.Category == category).ToList();
            if (products.Any())
            {
                products.ForEach(p => Console.WriteLine($"{p.Id}. {p.Name}"));
              //  foreach (var product in products)
                //{
                  //  Console.WriteLine($"{product.Id}. {product.Name}");
                //}
            }
            else
            {
                Console.WriteLine($"\nAktualnie brak produktów z danej kateogrii - dodaj produkt do bazy.");
            }
        }

        private bool ItemsView(bool viewInMenu)
        {
            if (viewInMenu)
            {
                Console.Clear();
            }
            List<Product> products = _productService.GetAllItems();
            if (products.Any())
            {
                products.ForEach(p => Console.WriteLine($"{p.Id}. {p.Name}"));
            }
            else
            {
                Console.WriteLine($"\nAktualnie brak produktów - dodaj produkt do bazy.");
                return false;
            }
            return true;
        }

        private int ChoseItemView()
        {
            Console.Clear();
            int id = 0;
            Console.WriteLine("Wybierz produkt z listy: ");
            if (ItemsView(false))
            {
                var tempId = Console.ReadLine();
                Int32.TryParse(tempId, out id);
            }
            return id;
        }

        private int ChoseCategoryOfProductView()
        {
            Console.Clear();
            Console.WriteLine("Wybierz kategorie");
            int category;
            var productsView = _actionService.GetMenuActionsByMenuName("ProductsCategory");
            Console.WriteLine();
            productsView.ForEach(pV => Console.WriteLine($"{pV.Id}. {pV.Name}"));
            while (!Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out category))
            {
                Console.WriteLine("Wybierz kategorie ponownie");
            }
            if(!(new[] { 1, 2, 3, 4, 5 }.Contains(category)))
            {
                return 0;
            }
            return category;
        }
        private void GoToMenuView()
        {
            Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do menu produktów.");
            Console.ReadKey();
        }
    }
}
