using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class UserDataService
    {
        public UserData userData { get; private set; }

        public UserDataService()
        {
            userData = new UserData();
        }

        public void SetUserData(int age, double weight, int height)
        {
            userData.Age = age;
            userData.Weight = weight;
            userData.Height = height;
        }
    }
}
