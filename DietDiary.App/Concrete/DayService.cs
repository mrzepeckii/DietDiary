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

        public Day GetDayByDate(DateTime date)
        {
            Day chosenDay = Items.FirstOrDefault(d => d.Date == date);
            return chosenDay;
        }

    }
}
