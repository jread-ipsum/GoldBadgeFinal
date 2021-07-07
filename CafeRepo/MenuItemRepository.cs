using CafePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuItemRepository
    {
        private List<MenuItem> _menu = new List<MenuItem>();

        private int _count;
        //create
        public bool AddItemsToMenu(MenuItem menuItem)
        {
            if(menuItem is null)
            {
                return false;
            }
            _count++;
            menuItem.MealNumber = _count;
            _menu.Add(menuItem);
            return true;
        }
        //read
        public List<MenuItem> GetMenu()
        {
            return _menu;
        }
        //delete
        public bool RemoveItemFromMenu(int mealNumber)
        {
            MenuItem menuItem = GetItemByMealNumber(mealNumber);
            
            if (menuItem == null)
            {
                return false;
            }

            int initialCount = _menu.Count;
            _menu.Remove(menuItem);

            if(initialCount > _menu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public MenuItem GetItemByMealNumber(int mealNumber)
        {
            foreach(MenuItem menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
