using DietDiary.App.Concrete;
using DietDiary.Domain.Entity;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace DietDiary.Tests.Services
{
    public class MealServiceTests
    {

        [Fact]
        public void CalculateCalorific()
        {
            //Arrange
            List<Product> products = new List<Product> { new Product(10, 2, "something1", 100, 10, 10, 10),
            new Product(10, 2, "something2", 200, 10, 10, 10),
            new Product(10, 2, "something3", 300, 10, 10, 10),
            new Product(10, 2, "something4", 400, 10, 10, 10)};
            Meal meal = new Meal() { Id = 1, Category = 1, products = products };
            MealService mealService = new MealService();
            //Act
            var calorific = mealService.CalculateCalorific(meal);
            //Assert
            calorific.Should().Be(1000);
        }

        [Fact]
        public void CalculateProtiens()
        {
            //Arrange
            List<Product> products = new List<Product> { new Product(10, 2, "something1", 100, 30, 10, 10),
            new Product(10, 2, "something2", 200, 30, 10, 10),
            new Product(10, 2, "something3", 300, 15, 10, 10),
            new Product(10, 2, "something4", 400, 15, 10, 10)};
            Meal meal = new Meal() { Id = 1, Category = 1, products = products };
            MealService mealService = new MealService();
            //Act
            var proteins = mealService.CalculateProteins(meal);
            //Assert
            proteins.Should().Be(90);
        }

        [Fact]
        public void CalculateCarbos()
        {
            //Arrange
            List<Product> products = new List<Product> { new Product(10, 2, "something1", 100, 10, 15, 10),
            new Product(10, 2, "something2", 200, 10, 15, 10),
            new Product(10, 2, "something3", 300, 10, 20, 10),
            new Product(10, 2, "something4", 400, 10, 20, 10)};
            Meal meal = new Meal() { Id = 1, Category = 1, products = products };
            MealService mealService = new MealService();
            //Act
            var carbos = mealService.CalculateCarbos(meal);
            //Assert
            carbos.Should().Be(70);
        }

        [Fact]
        public void CalculateFats()
        {
            //Arrange
            List<Product> products = new List<Product> { new Product(10, 2, "something1", 100, 10, 10, 10),
            new Product(10, 2, "something2", 200, 10, 10, 10),
            new Product(10, 2, "something3", 300, 10, 10, 10),
            new Product(10, 2, "something4", 400, 10, 10, 10)};
            Meal meal = new Meal() { Id = 1, Category = 1, products = products };
            MealService mealService = new MealService();
            //Act
            var fats = mealService.CalculateFats(meal);
            //Assert
            fats.Should().Be(40);
        }


    }
}
