using DietDiary.App.Concrete;
using System;
using System.ComponentModel.Design;

namespace DietDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            //6. Pomiary ciała 
            //  6a. Wyswietl pomiary
            //  6b. Jesli uzytkownik chce zupdatowac to niech wcisnie XXX
            MenuActionService actionService = new MenuActionService();
            UserDataService userDataService = new UserDataService();
            ProductService productService = new ProductService();
            MealService mealService = new MealService();
            BodyMeasurementsService measurementsService = new BodyMeasurementsService();
            productService.AddNewProduct(1, 123, "wolowina", 30, 40, 10);
            productService.AddNewProduct(2, 400, "marchewka", 30, 50, 70);
            productService.AddNewProduct(3, 100, "mandarynka", 40, 10, 10);
            productService.AddNewProduct(4, 140, "ryz", 56, 13, 13);
            productService.AddNewProduct(5, 144, "skyr", 42, 11, 15);
            actionService = Initialize(actionService);
            while (true)
            {
                
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
                        var keyInfo = userDataService.UserDataView(actionService);
                        userDataService.SetUserData(keyInfo);
                        break;
                    case '2':
                        var keyInfoProd = productService.ProductsView(actionService);
                        productService.ListOfProductsView(keyInfoProd.KeyChar);
                        break;
                    case '3':
                        var keyInfoMeal = mealService.AddNewMealView(actionService);
                        var id = mealService.AddNewMeal(productService, keyInfoMeal.KeyChar);
                        break;
                    case '4':
                        var removeId = mealService.RemoveMealView();
                        mealService.RemoveMeal(removeId);
                        break;
                    case '5':
                        mealService.MealsView();
                        break;
                    case '6':
                        var keyInfoBody = measurementsService.BodyMeasurementsView(actionService);
                        measurementsService.UpdateBodyMesurements(keyInfoBody);
                        break;
                    default:
                        Console.WriteLine("\nNie ma takiej opcji w menu \r\n");
                        break;
                }
            }
        }
    }
}
