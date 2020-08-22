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
            int calorific = 0;
            foreach (var product in meal.products)
            {
                calorific += product.Calorific;
            }
            return calorific;
        }

        public double CalculateCarbos(Meal meal)
        {
            double carbos = 0;
            foreach (var product in meal.products)
            {
                carbos += product.Carbos;
            }
            return carbos;
        }
        public double CalculateProteins(Meal meal)
        {
            double proteins = 0;
            foreach (var product in meal.products)
            {
                proteins += product.Proteins;
            }
            return proteins;
        }
        public double CalculateFats(Meal meal)
        {
            double fats = 0;
            foreach (var product in meal.products)
            {
                fats += product.Fats;
            }
            return fats;
        }
    }
}
