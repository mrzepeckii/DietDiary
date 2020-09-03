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
        //zakutalizuj posilek -- TO DO 

        private readonly MenuActionService _actionService;
        private readonly MealService _mealService;
        private readonly DayService _dayService;
        private IService<Product> _productService;
        public MealManager(MenuActionService actionService, MealService mealService, IService<Product> productService, DayService dayService)
        {
            _actionService = actionService;
            _mealService = mealService;
            _productService = productService;
            _dayService = dayService;
        }

        public void ChoseOptionInMealMenu()
        {
            
            while (true)
            {
                Console.Clear();
                var productsView = _actionService.GetMenuActionsByMenuName("MealsMenu");
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
                        var day = _dayService.ChoseDayView(false);
                        if (day != null)
                        {
                            MealsView(day);
                        }
                        GoToMenuView();
                        break;
                    case '2':
                        var dayToShowCallorific = _dayService.ChoseDayView(false);
                        if(dayToShowCallorific != null)
                        {
                            CalorificWholeDayView(dayToShowCallorific);
                        }
                        GoToMenuView();
                        break;
                    case '3':
                        var category = ChoseCategoryView();
                        if(category != 0)
                        {
                            MealsView(category);
                        }
                        GoToMenuView();
                        break;
                    case '4':
                        var chosenMeal = ChoseMealView();
                        if (chosenMeal != null)
                        {
                            DetailMealView(chosenMeal);
                        }
                        GoToMenuView();
                        break;
                    case '5':
                        var dayAddMeal = _dayService.ChoseDayView(true);
                        if (dayAddMeal != null)
                        {
                            var idAdd = AddNewMeal(dayAddMeal);
                        }
                        break;
                    case '6':
                        break;
                    case '7':
                        var dayRemoveMeal = _dayService.ChoseDayView(false);
                        if (dayRemoveMeal != null)
                        {
                            RemoveMealFromDay(dayRemoveMeal);
                        }
                        GoToMenuView();
                        break;
                    case '8':
                        RemoveMealFromBase();
                        break;
                    default:
                        break;
                }
            }
        }

        public void CalorificWholeDayView(Day day)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine($"Podsumowanie dnia {day.Date}");
            Console.WriteLine($"Kalorczyność całego dnia - {_dayService.CalculateCalorificWholeDay(day)}");
            Console.WriteLine($"Zawartość węglowodanów - {_dayService.CalculateCarbosWholeDay(day)}");
            Console.WriteLine($"Zawartość białka - {_dayService.CalculateProteinsWholeDay(day)}");
            Console.WriteLine($"Zawartość tłuszczy - {_dayService.CalculateFatsWholeDay(day)}");
            Console.WriteLine("--------------------------------");
        }

        private string AskAboutName()
        {
            Console.WriteLine("\nWprowadź nazwę posiłku:");
            string name = Console.ReadLine();
            return name;
        }

        private int ChoseCategoryView()
        {
            Console.Clear();
            if (!_productService.GetAllItems().Any())
            {
                Console.WriteLine("\nNie ma produktów w bazie - dodaj produkt.");
                GoToMenuView();
                return 0;
            }
            var mealsView = _actionService.GetMenuActionsByMenuName("MealsCategory");
            Console.WriteLine();
            mealsView.ForEach(mV => Console.WriteLine($"{mV.Id}. {mV.Name}"));
            int category;
            while (!Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out category))
            {
                Console.WriteLine("Wybierz kategorie ponownie");
            }
            if (!new []{ 1, 2, 3, 4, 5 }.Contains(category))
            {
                Console.WriteLine("Nie ma takiej kategorii");
                return 0; 
            }
            return category;
        }

        private List<Product> AskUserAboutProductsView(List<Product> products)
        {
            int idOfProduct;
            Product productToAdd;
            while (true)
            {
                
                Console.WriteLine("\nW celu zakończenia dodawania produktów wybierz 0.");
                Console.WriteLine("Aktualna lista produktów w posiłku: ");
                products.ForEach(p => Console.WriteLine($"-{p.Name}"));
                    Console.WriteLine("----------------");
                Console.WriteLine("Wybierz produkt z listy:");
                _productService.GetAllItems().ForEach(p => Console.WriteLine($"\n{p.Id}.{p.Name}"));
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out idOfProduct);
                if (idOfProduct == 0)
                {
                    break;
                }
                productToAdd = _productService.GetItemById(idOfProduct);
                if (productToAdd == null)
                {
                    Console.WriteLine("\nNie ma takiego produktu");
                    continue;
                }
                products.Add(productToAdd);
                Console.Clear();
            }
            return products;
        }

        private void GoToMenuView()
        {
            Console.WriteLine("Wcisnij dowolny przycisk w celu powrotu do głównego menu.");
            Console.ReadKey();
        }

        private Meal ChoseMealView()
        {
            if (!_mealService.Items.Any())
            {
                Console.Clear();
                Console.WriteLine("Brak posiłków w bazie");
                return null;
            }
            int id;
            Console.WriteLine("\nWybierz posiłek z listy:");
            _mealService.Items.ForEach(m => MealView(m));
            var tempId = Console.ReadLine();
            Int32.TryParse(tempId, out id);
            Meal chosenMeal = _mealService.GetItemById(id);
            return chosenMeal;
        }

        private void MealView(Meal meal)
        {
            Console.WriteLine($"{meal.Id}. {meal.Name}");
        }

        private int AddNewMeal(Day day)
        {
            Console.Clear();
            int mealCategory = ChoseCategoryView();
            if (mealCategory == 0)
            {
                return 0;
            }
            List<Product> mealProducts = new List<Product>();
            AskUserAboutProductsView(mealProducts);
            if (!mealProducts.Any())
            {
                return 0;
            }
            string name = AskAboutName();
            var id = _mealService.GetLastId();
            Meal meal = new Meal() { Id = id +1, Category = mealCategory, products = mealProducts, Name = name};
            _mealService.AddItem(meal);
            day.MealsInDay.Add(meal);
            DetailMealView(meal);
            GoToMenuView();
            return meal.Id;
        }


        private Meal AskUserAboutMealToRemove( Day day)
        {
            int idOfMeal, decision;
            bool isMealChosen = false;
            Meal mealToRemove;
            do
            {
                Console.WriteLine("\nWybierz posiłek, który chcesz usunąć");
                if (day == null)
                {
                    _mealService.GetAllItems().ForEach(m => Console.WriteLine($"{m.Id}.{(NameOfMeal)m.Category} - {m.Name}"));
                    Int32.TryParse(Console.ReadLine(), out idOfMeal);
                    mealToRemove = _mealService.GetItemById(idOfMeal);
                }
                else
                {
                    day.MealsInDay.ForEach(m => Console.WriteLine($"{m.Id}.{(NameOfMeal)m.Category} - {m.Name}"));
                    Int32.TryParse(Console.ReadLine(), out idOfMeal);
                    mealToRemove = day.MealsInDay.FirstOrDefault(m => m.Id == idOfMeal);
                }
                if (mealToRemove == null)
                {
                    Console.WriteLine("Nie ma takiego posiłku");
                    continue;
                }
                isMealChosen = true;
            } while (!isMealChosen);
            DetailMealView(mealToRemove);
            Console.WriteLine("Czy na pewno chcesz usunąć ten posiłek?");
            Console.WriteLine("1 - Tak \n2 - Nie");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out decision);
            if (decision == 2)
            {
                mealToRemove = null;
            }
            return mealToRemove;
        }

        private void RemoveMealFromDay(Day day)
        {
            Console.Clear();
            if (!day.MealsInDay.Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków dla danego dnia - dodaj posiłek");
                GoToMenuView();
                return;
            }
            Meal mealToRemove = AskUserAboutMealToRemove(day);
            day.MealsInDay.Remove(mealToRemove);
        }

        private void RemoveMealFromBase()
        {
            Console.Clear();
            if (!_mealService.GetAllItems().Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków w bazie - dodaj posiłek");
                GoToMenuView();
                return;
            }
            Meal mealToRemove = AskUserAboutMealToRemove(null);

            _mealService.RemoveItem(mealToRemove);
        }

        private void DetailMealView(Meal meal)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine((NameOfMeal)meal.Category);
            Console.WriteLine("Lista produktów w posiłku: ");
            meal.products.ForEach(p => Console.WriteLine($"-{p.Name}"));
            Console.WriteLine("Kalorczyność posiłku - " + _mealService.CalculateCalorific(meal));
            Console.WriteLine("Zawartość węglowodanów - " + _mealService.CalculateCarbos(meal));
            Console.WriteLine("Zawartość białka - " + _mealService.CalculateProteins(meal));
            Console.WriteLine("Zawartość tłuszczy - " + _mealService.CalculateFats(meal));
            Console.WriteLine("--------------------------------");
        }

        private void MealsView(Day day)
        {
            Console.Clear();
            if (!day.MealsInDay.Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków dla wybranego dnia - dodaj posiłek");
                GoToMenuView();
                return;
            }
            day.MealsInDay.ToList().ForEach(m => MealView(m));
            GoToMenuView();
        }

        private void MealsView(int category)
        {
            var meals = _mealService.GetAllItems();
            Console.Clear();
            if (!meals.Any())
            {
                Console.WriteLine("\nAktualnie brak posiłków w bazie - dodaj posiłek");
                GoToMenuView();
                return;
            }
            meals.Where(m => m.Category == category).ToList().ForEach(m => MealView(m));
        }
    }
}
