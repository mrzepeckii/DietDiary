using DietDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Entity
{
    public class Meal : BaseEntity
    {
        public List<Product> products;
        public string Name { get; set; }

    }
    
}
