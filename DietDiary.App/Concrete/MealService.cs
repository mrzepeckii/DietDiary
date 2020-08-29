using DietDiary.App.Common;
using DietDiary.Domain.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class MealService : BaseService<Meal>
    {
        public int CalculateCalorific(Meal meal)
        {
            int calorific = meal.products.Sum(p => p.Calorific);
            return calorific;
        }

        public double CalculateCarbos(Meal meal)
        {
            double carbos = meal.products.Sum(p => p.Carbos);
            return carbos;
        }
        public double CalculateProteins(Meal meal)
        {
            double proteins = meal.products.Sum(p => p.Proteins);
            return proteins;
        }
        public double CalculateFats(Meal meal)
        {
            double fats = meal.products.Sum(p => p.Fats);
            return fats;
        }
    }
}
