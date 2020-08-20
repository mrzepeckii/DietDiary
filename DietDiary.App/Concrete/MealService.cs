using DietDiary.App.Common;
using DietDiary.Domain.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class MealService : BaseService<Meal>
    {
        //  public List<Meal> Meals;

        /*   public MealService()
           {
               Meals = new List<Meal>();
           }*/

        public ConsoleKeyInfo AddNewMealView(MenuActionService actionService)
        {
            Console.Clear();
            var productsView = actionService.GetMenuActionsByMenuName("AddNewMealMenu");
            Console.WriteLine();
            for (int i = 0; i < productsView.Count; i++)
            {
                Console.WriteLine($"{productsView[i].Id}. {productsView[i].Name}");
            }
            var chosenOption = Console.ReadKey();
            return chosenOption;
        }

        public int AddNewMeal(ProductService productService, char category)
        {

            int mealCategory, idOfMeal;
            int idOfProduct = 1;
            Product tempProduct;
            List<Product> products = new List<Product>();
            int.TryParse(category.ToString(), out mealCategory);
            if (mealCategory == 0)
                return 0;
            while (true)
            {
                Console.WriteLine("\nW celu zakończenia dodawania produktów wybierz 0.");
                Console.WriteLine("Wybierz produkt z listy:");
                productService.ListOfProductsView();
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out idOfProduct);
                if (idOfProduct == 0)
                    break;
                if (!productService.Products.Exists(x => x.Id == idOfProduct))
                {
                    Console.WriteLine("\nNie ma takiego produku");
                    continue;
                }
                tempProduct = productService.FindProductById(idOfProduct);
                products.Add(tempProduct);
                Console.WriteLine($"\nDodano {tempProduct.Name}");
                Console.Clear();
            }
            if (products.Count == 0)
                return 0;
            Console.Clear();
            Console.WriteLine("\nWprowadz ID posiłku: ");
            while (!int.TryParse(Console.ReadLine().ToString(), out idOfMeal)) { Console.WriteLine("ID musi być liczbą całkowitą"); };
            Meal meal = new Meal() { Category = mealCategory, Id = idOfMeal, products = products };
            Items.Add(meal);
            MealView(meal);
            return meal.Id;
        }

        private int CalculateCalorific(Meal meal)
        {
            int calorific = 0;
            foreach (var product in meal.products)
                calorific += product.Calorific;
            return calorific;
        }

        private double CalculateCarbos(Meal meal)
        {
            double carbos = 0;
            foreach (var product in meal.products)
                carbos += product.Carbos;
            return carbos;
        }
        private double CalculateProteins(Meal meal)
        {
            double proteins = 0;
            foreach (var product in meal.products)
                proteins += product.Proteins;
            return proteins;
        }
        private double CalculateFats(Meal meal)
        {
            double fats = 0;
            foreach (var product in meal.products)
                fats += product.Fats;
            return fats;
        }

        public void MealView(Meal meal)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine((NameOfMeal)meal.Category);
            Console.WriteLine("Lista produktów w posiłku: ");
            foreach (var item in meal.products)
            {
                Console.WriteLine($"-{item.Name}");
            }

            Console.WriteLine("Kalorczyność posiłku - " + CalculateCalorific(meal));
            Console.WriteLine("Zawartość węglowodanów - " + CalculateCarbos(meal));
            Console.WriteLine("Zawartość białka - " + CalculateProteins(meal));
            Console.WriteLine("Zawartość tłuszczy - " + CalculateFats(meal));
            Console.WriteLine("--------------------------------");
        }

        public void CalorificWholeDayView()
        {
            int calorificWholeDay = 0;
            double carbosDay = 0, fatsDay = 0, proteinsDay = 0;

            foreach (var meal in Items)
            {
                calorificWholeDay += CalculateCalorific(meal);
                carbosDay += CalculateCarbos(meal);
                fatsDay += CalculateFats(meal);
                proteinsDay += CalculateProteins(meal);
            }
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("Podsumowanie dnia");
            Console.WriteLine($"Kalorczyność całego dnia - {calorificWholeDay}");
            Console.WriteLine($"Zawartość węglowodanów - {carbosDay}");
            Console.WriteLine($"Zawartość białka - {proteinsDay}");
            Console.WriteLine($"Zawartość tłuszczy - {fatsDay}");
            Console.WriteLine("--------------------------------");
        }

        public void MealsView()
        {
            if (!Items.Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków - dodaj posiłek");
            }

            foreach (var meal in Items)
            {
                MealView(meal);
            }

            CalorificWholeDayView();
        }

        /* public Meal FindMealById(int idOfMeal)
         {
             Meal tempMeal = new Meal();
             foreach (var meal in Meals)
                 if (meal.Id == idOfMeal)
                 {
                     tempMeal = meal;
                     break;
                 }
             return tempMeal;
         }*/

        public int RemoveMealView()
        {
            if (!Items.Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków - dodaj posiłek");
                return 0;
            }
            int idOfMeal, decision;
            bool isMealChosen = false;
            do
            {
                Console.WriteLine("\nWybierz posiłek, który chcesz usunąć");
                foreach (var meal in Items)
                {
                    Console.WriteLine($"{meal.Id}.{(NameOfMeal)meal.Category}");
                }

                Int32.TryParse(Console.ReadLine(), out idOfMeal);
                if (GetItemById(idOfMeal) == null)
                {
                    Console.WriteLine("Nie ma takiego posiłku");
                    continue;
                }
                isMealChosen = true;

            } while (!isMealChosen);
            MealView(GetItemById(idOfMeal));
            Console.WriteLine("Czy na pewno chcesz usunąć ten posiłek?");
            Console.WriteLine("1 - Tak \n2 - Nie");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out decision);
            if (decision == 2)
            {
                return 0;
            }
            return idOfMeal;
        }

        /* public void RemoveMeal(int removeId)
         {
             Meal tempMeal = new Meal();
             foreach (var meal in Meals)
             {
                 if (meal.Id == removeId)
                     tempMeal = meal;
                 break;
             }
             Meals.Remove(tempMeal);
         }*/
    }
}
