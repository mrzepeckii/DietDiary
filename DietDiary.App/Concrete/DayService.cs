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

        private Day GetDayByDate(DateTime date)
        {
            Day chosenDay = Items.FirstOrDefault(d => d.Date == date);
            return chosenDay;
        }

        public Meal GetMealFromDayById(Day day, int id)
        {
           Meal meal = day.MealsInDay.FirstOrDefault(m => m.Id == id);
            return meal;
        }
        public Day ChoseDayView()
        {
            DateTime dateTime;
            Day chosenDay;
            Console.WriteLine("\nProszę wpisać datę:");
            DateTime.TryParse(Console.ReadLine(), out dateTime);
            chosenDay = GetDayByDate(dateTime);
            if (chosenDay == null)
            {
                Console.WriteLine("Brak wyników z bazy - w tym dniu nie dodano żadnego posiłku");
            }
            return chosenDay;

        }

    }
}
