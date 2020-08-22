using DietDiary.App.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Managers
{
    public class UserDataManager
    {
        private readonly UserDataService _userDataService;
        private readonly MenuActionService _actionService;

        public UserDataManager(UserDataService userDataService, MenuActionService actionService)
        {
            _userDataService = userDataService;
            _actionService = actionService;
        }
        public void SetUserData(MenuActionService actionService)
        {
            Console.Clear();
            var userDataMenu = actionService.GetMenuActionsByMenuName("UserDataMenu");
            Console.WriteLine($"\nTwoje aktualne dane: \r\n{_userDataService.userData}");
            for (int i = 0; i < userDataMenu.Count; i++)
                Console.WriteLine($"{userDataMenu[i].Id}. {userDataMenu[i].Name}");
            var chosenOption = Console.ReadKey();
            if (chosenOption.KeyChar != '1')
                return;
            int age = 0;
            double weight = 0;
            int height = 0;
            Console.WriteLine("\nPodaj wiek: ");
            while (!Int32.TryParse(Console.ReadLine(), out age)) { Console.WriteLine("Zly typ danych, podaj liczbę całkowitą"); };
            Console.WriteLine("Podaj wagę: ");
            while (!double.TryParse(Console.ReadLine(), out weight)) { Console.WriteLine("Zly typ danych, podaj liczbę"); };
            Console.WriteLine("Podaj wzrost: ");
            while (!Int32.TryParse(Console.ReadLine(), out height)) { Console.WriteLine("Zly typ danych, podaj liczbę całkowitą"); };
            _userDataService.SetUserData(age, weight, height);
        }
    }
}
