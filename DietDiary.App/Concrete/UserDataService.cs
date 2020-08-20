using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class UserDataService
    {
        public UserData userData { get; private set; }

        public UserDataService()
        {
            userData = new UserData();
        }

        public ConsoleKeyInfo UserDataView(MenuActionService actionService)
        {
            var userDataMenu = actionService.GetMenuActionsByMenuName("UserDataMenu");
            Console.WriteLine($"\nTwoje aktualne dane: \r\n{userData}");
            for (int i = 0; i < userDataMenu.Count; i++)
                Console.WriteLine($"{userDataMenu[i].Id}. {userDataMenu[i].Name}");

            var chosenOption = Console.ReadKey();
            return chosenOption;
        }

        public void SetUserData(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar != '1')
                return;
            int age = 0;
            double weight = 0;
            int height = 0;
            Console.WriteLine("\nPodaj wiek: ");
            while(!Int32.TryParse(Console.ReadLine(), out age)) { Console.WriteLine("Zly typ danych, podaj liczbę całkowitą"); };
            userData.Age = age;
            Console.WriteLine("Podaj wagę: ");
            while (!double.TryParse(Console.ReadLine(), out weight)) { Console.WriteLine("Zly typ danych, podaj liczbę"); };
            userData.Weight = weight;
            Console.WriteLine("Podaj wzrost: ");
            while (!Int32.TryParse(Console.ReadLine(), out height)) { Console.WriteLine("Zly typ danych, podaj liczbę całkowitą"); };
            userData.Height = height;
        }
    }
}
