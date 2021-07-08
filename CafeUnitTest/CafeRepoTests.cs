using CafePOCO;
using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void Create_()
        {
            //arrange -create any variables we need to test this method
            MenuItem menuItem = null;
            MenuItemRepository repo = new MenuItemRepository();

            //act - actually calling the method
            bool result = repo.AddItemsToMenu(menuItem);
            // assert -making sure the method did what it was supposed to 
            Assert.IsFalse(result);
        }
    }
}
