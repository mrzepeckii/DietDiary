using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Calorific { get; set; }
        public double Proteins { get; set; }
        public double Carbos { get; set; }
        public double Fats { get; set; }

        public Product()
        {

        }

        public Product(int id, int category, string name, int calorific, double proteins, double carbos, double fats)
        {
            Id = id;
            Category = category;
            Name = name;
            Calorific = calorific;
            Proteins = proteins;
            Carbos = carbos;
            Fats = fats;
        }

    }
}
