using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPattern_Repository;
using System;
using System.Collections.Generic;

namespace RepositoryPattern_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ReepositoryPatterN_Repository
        {
            private MenuContentRepository _testMenu = new MenuContentRepository();

            [TestMethod]
            public void GetMenuByNameTest()
            {
                SeedMenuList();
                string realMenu = "Real Pistachio Cupcake";
                string falseMenu = "Lazania";

                MenuContent realResultMenu, falseResultMenu;

                //Act
                realResultMenu = _testMenu.GetMenuByName(realMenu);
                falseResultMenu = _testMenu.GetMenuByName(falseMenu);

                //Assert
                Assert.IsNotNull(realResultMenu);
                Assert.IsNull(falseResultMenu);
            }
            public void TestMethod1_AddFoodToMenu()
            {
                //Arrange
                MenuContent menu = new MenuContent();
                MenuContentRepository repo = new MenuContentRepository();
                List<MenuContent> localMenu = repo.ReturnMenuList();

                //Act;
                int beforeCount = localMenu.Count;
                repo.AddFoodToMenu(menu);
                int actual = localMenu.Count;
                int expected = beforeCount + 1;

                //Assert
                Assert.AreEqual(expected, actual);
            }
            private void SeedMenuList()
            {
                MenuContent realpistachiocupcakes = new MenuContent(1, "Real Pistachio Cupcake", 2.99, "roasted pistachio nut meatsm",
                 " 1 & 1/2 cups white sugar\n" +
                 ", 3/4 flour, 2 teaspoons baking powder\n" +
                 ", 3/4 salt, unsalted butter\n" +
                 ", 4 large egg\n" +
                 ", 2/4 cup of mlk\n" +
                 ", 2 teaspoon of vanilla", TypesOfFood.Muffins);
                MenuContent americanos = new MenuContent(2, "Columbian Coffee", 3.99, "dark coffee", "Coffee beans from Columbia finely roasted", TypesOfFood.Coffee);
                MenuContent cookiesandcreamcake = new MenuContent(3, "Cookies & Cream Cake", 5.99, "oreos cookies mashed with ice cream", "24 Vanilla ice crea\n" +
                    ", 2 crushed oreo cookies\n" +
                    ", 1 jar hot fudge ice cream\n" +
                    ", 1 jar caramel ice cream topping\n" +
                    ", and chopped peacans", TypesOfFood.Cake);

                _testMenu.AddFoodToMenu(realpistachiocupcakes);
                _testMenu.AddFoodToMenu(americanos);
                _testMenu.AddFoodToMenu(cookiesandcreamcake);
            }
            [TestMethod] 
            public void AddMenuToList()
            {
                SeedMenuList();
                string addToMenu = "Tiramisu";

                MenuContent resultMenu;

                //Act
                resultMenu = _testMenu.GetMenuByName(addToMenu);
                if(resultMenu != null)
                {
                    Assert.Fail("The Food allready exist in repository");
                }
                else
                {
                    _testMenu.AddFoodToMenu(new MenuContent { MealNumber = 7, Name = "Tiramisu", Description = "Layers of cream and cake with coffee", Price = 11.99, Ingredients = "6 egg yolks\n 3 table spoons sugar\n 1 pound mascarpone cheese\n 2 teasppons dark rum\n 24 packed ladyfingers \n 1/2 cup bittersweet choclate shavings, for garnish", FoodType = TypesOfFood.Cake});
                }

                resultMenu = _testMenu.GetMenuByName(addToMenu);

                //Assert
                Assert.IsNotNull(resultMenu);
            }
        }
    }

}
