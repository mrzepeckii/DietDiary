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
    public class MealManager
    {

        private readonly MenuActionService _actionService;
        private readonly MealService _mealService;
        private IService<Product> _productService;

        public MealManager(MenuActionService actionService, MealService mealService, IService<Product> productService)
        {
            _actionService = actionService;
            _mealService = mealService;
            _productService = productService;
        }

        public int AddNewMeal()
        {
            Console.Clear();
            if (!_productService.GetAllItems().Any())
            {
                Console.WriteLine("Nie ma produktów w bazie - dodaj produkt.");
                Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do głównego menu.");
                Console.ReadKey();
                return 0;
            }
            var mealsView = _actionService.GetMenuActionsByMenuName("AddNewMealMenu");
            Console.WriteLine();
            for (int i = 0; i < mealsView.Count; i++)
            {
                Console.WriteLine($"{mealsView[i].Id}. {mealsView[i].Name}");
            }
            var category = Console.ReadKey();

            int mealCategory, idOfMeal, idOfProduct;
            Product productToAdd;
            List<Product> products = new List<Product>();
            Int32.TryParse(category.KeyChar.ToString(), out mealCategory);
            if (mealCategory == 0)
            {
                return 0;
            }
            while (true)
            {
                Console.WriteLine("\nW celu zakończenia dodawania produktów wybierz 0.");
                Console.WriteLine("Wybierz produkt z listy:");
                //_productService.ListOfProductsView();
                foreach (var product in _productService.GetAllItems())
                {
                    Console.WriteLine($"\n{product.Id}.{product.Name}");
                }  
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out idOfProduct);
                if (idOfProduct == 0)
                    break;
                productToAdd = _productService.GetItemById(idOfProduct);
                if(productToAdd == null)
                {
                    Console.WriteLine("\nNie ma takiego produktu");
                    continue;
                }
                products.Add(productToAdd);
                Console.WriteLine($"\nDodano {productToAdd.Name}");
                Console.Clear();
            }
            if (products.Count == 0)
                return 0;
            Console.Clear();
            Console.WriteLine("\nWprowadz ID posiłku: ");
            while (!int.TryParse(Console.ReadLine().ToString(), out idOfMeal)) { Console.WriteLine("ID musi być liczbą całkowitą"); };
            var id = _mealService.GetLastId();
            Meal meal = new Meal() { Id = id +1, Category = mealCategory, products = products };
            _mealService.AddItem(meal);
            _mealService.MealView(meal);
            Console.WriteLine($"Wcisnij dowolny przycisk w celu powrotu do głównego menu.");
            Console.ReadKey();
            return meal.Id;
        }

        public void RemoveMeal()
        {
            if (!_mealService.GetAllItems().Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków - dodaj posiłek");
                return;
            }
            int idOfMeal, decision;
            bool isMealChosen = false;
            Meal mealToRemove;
            do
            {
                Console.WriteLine("\nWybierz posiłek, który chcesz usunąć");
                foreach (var meal in _mealService.GetAllItems())
                {
                    Console.WriteLine($"{meal.Id}.{(NameOfMeal)meal.Category}");
                }

                Int32.TryParse(Console.ReadLine(), out idOfMeal);
                mealToRemove = _mealService.GetItemById(idOfMeal);
                if(mealToRemove == null)
                {
                    Console.WriteLine("Nie ma takiego posiłku");
                    continue;
                }
                isMealChosen = true;
            } while (!isMealChosen);
            _mealService.MealView(mealToRemove);
            Console.WriteLine("Czy na pewno chcesz usunąć ten posiłek?");
            Console.WriteLine("1 - Tak \n2 - Nie");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out decision);
            if (decision == 2)
            {
                return;
            }
        }





    }
}
