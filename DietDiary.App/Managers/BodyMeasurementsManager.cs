using DietDiary.App.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DietDiary.App.Managers
{
    public class BodyMeasurementsManager
    {
        private readonly MenuActionService _actionService;
        private readonly BodyMeasurementsService _bodyService;

        public BodyMeasurementsManager(BodyMeasurementsService bodyService, MenuActionService actionService)
        {
            _bodyService = bodyService;
            _actionService = actionService;
        }

        public void UpdateBodyMesurements()
        {
            Console.Clear();
            var userDataMenu = _actionService.GetMenuActionsByMenuName("BodyMeasurementsMenu");
            Console.WriteLine($"\nTwoje aktualne pomiary:\n{_bodyService.body}");
            for (int i = 0; i < userDataMenu.Count; i++)
                Console.WriteLine($"{userDataMenu[i].Id}. {userDataMenu[i].Name}");
            var chosenOption = Console.ReadKey();
            if (chosenOption.KeyChar != '1')
                return;
            Console.Clear();
            int calf, thight, waist, chest, biceps;
            Console.WriteLine("\nPodaj pomiar łydki: ");
            while (!Int32.TryParse(Console.ReadLine(), out calf)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            Console.WriteLine("Podaj pomiar uda: ");
            while (!Int32.TryParse(Console.ReadLine(), out thight)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            Console.WriteLine("Podaj pomiar tali: ");
            while (!Int32.TryParse(Console.ReadLine(), out waist)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            Console.WriteLine("Podaj pomiar klatki: ");
            while (!Int32.TryParse(Console.ReadLine(), out chest)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            Console.WriteLine("Podaj pomiar bicepsa: ");
            while (!Int32.TryParse(Console.ReadLine(), out biceps)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            _bodyService.SetBodyMeasuremnts(calf, thight, waist, chest, biceps);
        }


    }
}
