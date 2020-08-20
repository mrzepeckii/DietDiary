using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
        //  public string Name { get; set; }
        public int Category { get; set; }

    }
}
