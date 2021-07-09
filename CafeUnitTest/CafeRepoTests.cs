using CafePOCO;
using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeUnitTest
{
    [TestClass]
    public class CafeRepoTests
    {
        private readonly MenuItemRepository _repo = new MenuItemRepository();

        [TestInitialize]
        public void Arrange()
        {
            MenuItem menuItem = new MenuItem("BLT", "bacon lettuce and tomato sandwich", "bacon, lettuce, tomato, bread", 4.99);
            _repo.AddItemsToMenu(menuItem);
        }

        [TestMethod]
        public void AddItemsToMenu_MenuItemIsNull_ReturnFalse()
        {
            //arrange -create any variables we need to test this method
            MenuItem menuItem = null;
            MenuItemRepository repo = new MenuItemRepository();

            //act - actually calling the method
            bool result = repo.AddItemsToMenu(menuItem);

            // assert -making sure the method did what it was supposed to 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddItemsToMenu_MenuItemIsNotNull_ReturnTrue()
        {
            MenuItem menuItem = new MenuItem("BLT", "bacon lettuce and tomato sandwich", "bacon, lettuce, tomato, bread", 4.99);

            bool result = _repo.AddItemsToMenu(menuItem);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetItemByMealNumber_MenuItemExists_ReturnMenuItem()
        {
            int mealNumber = 1;

            MenuItem result = _repo.GetItemByMealNumber(mealNumber);

            Assert.AreEqual(result.MealNumber, mealNumber);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetItemByMealNumber_MenuItemDoesNotExist_ReturnNull()
        {
            int mealNumber = 33;

            MenuItem result = _repo.GetItemByMealNumber(mealNumber);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void RemoveItemFromMenu_MenuItemIsNull_ReturnFalse()
        {
            int mealNumber = 33;

            bool result = _repo.RemoveItemFromMenu(mealNumber);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveItemFromMenu_MenuItemIsNotNull_ReturnTrue()
        {
            int mealNumber = 1;

            bool result = _repo.RemoveItemFromMenu(mealNumber);

            Assert.IsTrue(result);
        }
    }
}
