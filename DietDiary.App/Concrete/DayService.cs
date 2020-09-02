using DietDiary.App.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class DayService : BaseService<Day>
    {
        private readonly MealService _mealService;

        public DayService(string path, MealService mealService)
        {
            Items = ReadItemsFromXml("Days", path).ToList();
            _mealService = mealService;
        }
        public int CalculateCalorificWholeDay(Day day)
        {
            int calorificWholeDay = day.MealsInDay.Sum(m => _mealService.CalculateCalorific(m));
            return calorificWholeDay;
        }

        public double CalculateCarbosWholeDay(Day day)
        {
            double carbosDay = day.MealsInDay.Sum(m => _mealService.CalculateCarbos(m));
            return carbosDay;
        }
        public double CalculateProteinsWholeDay(Day day)
        {
            double proteinsDay = day.MealsInDay.Sum(m => _mealService.CalculateProteins(m));
            return proteinsDay;
        }

        public double CalculateFatsWholeDay(Day day)
        {

            double fatsDay = day.MealsInDay.Sum(m => _mealService.CalculateFats(m));
            return fatsDay;
        }

        public Meal GetMealFromDayById(Day day, int id)
        {
            Meal meal = day.MealsInDay.FirstOrDefault(m => m.Id == id);
            return meal;
        }
        public Day ChoseDayView(bool addDay)
        {
            DateTime dateTime;
            Day chosenDay;
            Console.WriteLine("\nProszę wpisać datę:");
            DateTime.TryParse(Console.ReadLine(), out dateTime);
            chosenDay = GetDayByDate(dateTime);
            if (chosenDay == null)
            {
                if (addDay)
                {
                    int id = GetLastId();
                    chosenDay = new Day(id +1, dateTime);
                    Items.Add(chosenDay);
                }
                else
                {
                    Console.WriteLine("Brak wyników z bazy - w tym dniu nie dodano żadnego posiłku");
                    Console.ReadKey();
                }
            }
            return chosenDay;
        }

        private Day GetDayByDate(DateTime date)
        {
            Day chosenDay = Items.FirstOrDefault(d => d.Date == date);
            return chosenDay;
        }
    }
}
