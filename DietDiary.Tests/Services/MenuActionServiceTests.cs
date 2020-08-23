using DietDiary.App.Concrete;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DietDiary.Tests.Services
{
    public class MenuActionServiceTests
    {
        [Fact]
        public void MenuActionShouldBeNullOrEmpty()
        {
            //Arrange
            MenuActionService actionService = new MenuActionService();
            //Act
            var menuAction = actionService.GetMenuActionsByMenuName("nullMenu");
            //Assert
            menuAction.Should().BeNullOrEmpty();
        }

        [Fact]
        public void MenuActionShouldBeNotNull()
        {
            //Arrange
            MenuActionService actionService = new MenuActionService();
            //Act
            var menuAction = actionService.GetMenuActionsByMenuName("Main");
            //Assert
            menuAction.Count.Should().Be(7);
        }
    }
}
