using DietDiary.App.Concrete;
using DietDiary.App.Managers;
using DietDiary.Domain.Entity;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DietDiary.Tests.Managers
{
    public class MealManagerTest
    {
        [Fact]
        public void CalculateCalorificWholeDay()
        {
            //Arrange
            Product product = new Product(10, 2, "something", 300, 30, 10, 29);
            Meal meal = new Meal();
            MealService mealService = new MealService
            {
                Items = new List<Meal>() { new Meal { Id = 1, Category = 1, products = new List<Product>() { product } },
                new Meal { Id = 2, Category = 3, products = new List<Product>() { product } },
                new Meal { Id = 3, Category = 4, products = new List<Product>() { product } } }
            };
            //Moq - Non-overridable members may not be used in setup / verification expressions
            //var mock = new Mock<MealService>();
            /*  mock.Setup(p => p.Items).Returns(new List<Meal>(){new Meal { Id = 1, Category = 1, products = new List<Product>() { product } },
                  new Meal { Id = 2, Category = 3, products = new List<Product>() { product } },
                      new Meal { Id = 3, Category = 4, products = new List<Product>() { product } } });*/
            var manager = new MealManager(new MenuActionService(), mealService, new ProductService());
            //Act
            var calorific = manager.CalorificWholeDayView();
            //Assert
            calorific.Should().Be(900);
        }
    }
}
