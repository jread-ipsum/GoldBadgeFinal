using CafePOCO;
using CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeUI
{
    public class ProgramUI
    {
        private readonly MenuItemRepository _menuItemRepository = new MenuItemRepository();
        public void Run()
        {
            SeedMenu();
            AppMenu();
        }

        private void AppMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("======Komodo Cafe Menu=======");
                Console.WriteLine("Select an option:\n" +
                    "1. View Menu\n" +
                    "2. Add Item to Menu\n" +
                    "3. Remove Item from Menu\n" +
                    "4. Exit\n");

                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        ViewMenu();
                        break;
                    case "2":
                        AddItemToMenu();
                        break;
                    case "3":
                        RemoveItemFromMenu();
                        break;
                    case "4":
                        Console.WriteLine("Thank you, come again!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------MENU-------------------------------");

            List<MenuItem> menuItems = _menuItemRepository.GetMenu(); 
            foreach(MenuItem menuItem in menuItems)
            {
                Console.WriteLine($"-------------------------------------------------------------------\n" +
                    $"{menuItem.MealNumber} {menuItem.MealName}\n\n" +
                    $"{menuItem.Description}\n" +
                    $"Ingredients: {menuItem.Ingredients}\n" +
                    $"Price: {menuItem.Price}\n");
            }
        }

        private void AddItemToMenu()
        {
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Enter a meal name.");
            newMenuItem.MealName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter a meal description.");
            newMenuItem.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the meal ingredients.");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter a price for the meal.");
            newMenuItem.Price = double.Parse(Console.ReadLine());

            _menuItemRepository.AddItemsToMenu(newMenuItem);

            Console.WriteLine("\nItem has been added to the Menu.");
        }

        private void RemoveItemFromMenu()
        {
            Console.Clear();

            Console.WriteLine("Enter the meal number for the item you would like to remove.");
            int mealNumber = int.Parse(Console.ReadLine());

            MenuItem menuItem = _menuItemRepository.GetItemByMealNumber(mealNumber);
            if (menuItem is null)
            {
                Console.WriteLine("\nSorry, no menu item found");
            }
            else
            {
                _menuItemRepository.RemoveItemFromMenu(mealNumber);
                Console.WriteLine("\nItem has been removed from the menu.");
            }
        }

        private void SeedMenu()
        {
            MenuItem menuItem1 = new MenuItem("BLT", "Bacon, Lettuce, and Tomato Sandwich", "Bread, Bacon, Lettuce, Tomato", 4.99);
            MenuItem menuItem2 = new MenuItem("Turkey Sandwich", "Our famous loaded turkey sandwich", "Roasted Turkey Breast, Swiss Cheese, Tomato, Onion, Lettuce, Rye Bread", 6.99);
            MenuItem menuItem3 = new MenuItem("Loaded Baked Potato", "A giant russet potato with all the fixins", "Potato, Sour Cream, Bacon, Cheddar Cheese, Green Onions, Butter", 5.49);
            MenuItem menuItem4 = new MenuItem("House Salad", "A mixed greens salad with enough substance to fill any stomach", "Mixed Greens, Sliced Apples, Candied Almonds, Cranberries, Prosecco Pear Vinaigrette", 5.79);

            _menuItemRepository.AddItemsToMenu(menuItem1);
            _menuItemRepository.AddItemsToMenu(menuItem2);
            _menuItemRepository.AddItemsToMenu(menuItem3);
            _menuItemRepository.AddItemsToMenu(menuItem4);
        }
    }
}
