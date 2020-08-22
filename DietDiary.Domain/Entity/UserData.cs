﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.Domain.Entity
{
    public class UserData
    {
        public int Age { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return "Wiek - " + Age + "\r\nWzrost - " + Height + "\r\nWaga - " + Weight;
        }
    }
}
