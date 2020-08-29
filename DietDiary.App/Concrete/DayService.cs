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
        public int CalculateCalorific(IEnumerable<Meal> meals)
        {
            meals.ToList().ForEach(m => _mealService.CalculateCalorific(m));

        }

    }
}
