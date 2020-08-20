using DietDiary.App.Abstract;
using DietDiary.App.Concrete;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Managers
{
    public class MealManager
    {

        private readonly MenuActionService _actionService;
        private readonly MealService _mealService;
        private IService<Product> _productService;
        public int AddNewMeal()
        {
            Console.Clear();
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
            Int32.TryParse(category.ToString(), out mealCategory);
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
                    Console.WriteLine("\nNie ma takiego produku");
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
            return meal.Id;
        }



    }
}
