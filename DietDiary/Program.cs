using DietDiary.App.Concrete;
using DietDiary.App.Managers;
using DietDiary.Domain.Entity;
using System;
using System.ComponentModel.Design;

namespace DietDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            UserDataService userDataService = new UserDataService();
            ProductService productService = new ProductService();
            MealService mealService = new MealService();
            BodyMeasurementsService measurementsService = new BodyMeasurementsService();
            ProductManager productManager = new ProductManager(productService, actionService);
            MealManager mealManager = new MealManager(actionService, mealService, productService);
            UserDataManager userDataManager = new UserDataManager(userDataService, actionService);
            BodyMeasurementsManager bodyManager = new BodyMeasurementsManager(measurementsService, actionService);
            while (true)
            {
                Console.Clear();
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
               Console.WriteLine();
                for (int i = 0; i < mainMenu.Count; i++)
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                var chosenOption = Console.ReadKey();
                switch (chosenOption.KeyChar)
                {
                    case '0':
                        Environment.Exit(0);
                        break;
                    case '1':
                        userDataManager.SetUserData(actionService);
                        break;
                    case '2':
                        productManager.ChoseOptionInProductMenu();
                        break;
                    case '3':
                        var mealId = mealManager.AddNewMeal();
                        break;
                    case '4':
                        mealManager.RemoveMeal();
                        break;
                    case '5':
                        mealManager.MealsView();
                        break;
                    case '6':
                        bodyManager.UpdateBodyMesurements();
                        break;
                    default:
                        Console.WriteLine("\nNie ma takiej opcji w menu \r\n");
                        break;
                }
            }
        }
    }
}
