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
            ProductService productService = new ProductService(@"C:\Temp\products.xml");
            MealService mealService = new MealService(@"C:\Temp\meals.xml");
            DayService dayService = new DayService(@"C:\Temp\days.xml",mealService);
            BodyMeasurementsService measurementsService = new BodyMeasurementsService();
            ProductManager productManager = new ProductManager(productService, actionService);
            MealManager mealManager = new MealManager(actionService, mealService, productService, dayService);
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
                        productService.SaveItemsToXml("Products", @"C:\Temp\products.xml");
                        mealService.SaveItemsToXml("Meals", @"C:\Temp\meals.xml");
                        dayService.SaveItemsToXml("Days", @"C:\Temp\days.xml");
                        Environment.Exit(0);
                        break;
                    case '1':
                        userDataManager.SetUserData(actionService);
                        break;
                    case '2':
                        productManager.ChoseOptionInProductMenu();
                        break;
                    case '3':
                        mealManager.ChoseOptionInMealMenu();
                        break;
                    case '4':
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
