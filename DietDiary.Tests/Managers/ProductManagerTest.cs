using DietDiary.App.Abstract;
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
    public class ProductManagerTest
    {
        [Fact]
        public void RemoveProduct()
        {
            //Arrange
            Product product = new Product(10, 2, "something", 300, 30, 10, 29);
            var mock = new Mock<IService<Product>>();
            mock.Setup(p => p.GetItemById(10)).Returns(product);
            mock.Setup(p => p.RemoveItem(It.IsAny<Product>()));
            var manager = new ProductManager(mock.Object,new MenuActionService());
            //Act
            manager.RemoveItemById(product.Id);
            //Assert
            mock.Verify(p => p.RemoveItem(product));
        }

    }
}
