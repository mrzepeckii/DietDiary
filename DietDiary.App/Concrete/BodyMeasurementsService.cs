using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class BodyMeasurementsService
    {

        public BodyMeasurements body { get; private set; }

        public BodyMeasurementsService()
        {
            body = new BodyMeasurements();
        }

        public ConsoleKeyInfo BodyMeasurementsView(MenuActionService actionService)
        {
            var userDataMenu = actionService.GetMenuActionsByMenuName("BodyMeasurementsMenu");
            Console.WriteLine($"\nTwoje aktualne pomiary:\n{body}");
            for (int i = 0; i < userDataMenu.Count; i++)
                Console.WriteLine($"{userDataMenu[i].Id}. {userDataMenu[i].Name}");

            var chosenOption = Console.ReadKey();
            return chosenOption;
        }

        public void UpdateBodyMesurements(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar != '1')
                return;
            int calf, thight, waist, chest, biceps;
            Console.WriteLine("\nPodaj pomiar łydki: ");
            while (!Int32.TryParse(Console.ReadLine(), out calf)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            body.Calf = calf;
            Console.WriteLine("Podaj pomiar uda: ");
            while (!Int32.TryParse(Console.ReadLine(), out thight)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            body.Thight = thight;
            Console.WriteLine("Podaj pomiar tali: ");
            while (!Int32.TryParse(Console.ReadLine(), out waist)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            body.Waist = waist;
            Console.WriteLine("Podaj pomiar klatki: ");
            while (!Int32.TryParse(Console.ReadLine(), out chest)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            body.Chest = chest;
            Console.WriteLine("Podaj pomiar bicepsa: ");
            while (!Int32.TryParse(Console.ReadLine(), out biceps)) { Console.WriteLine("Zly typ danych, podaj wartość liczbową"); };
            body.Biceps = biceps;

        }
    }
}
