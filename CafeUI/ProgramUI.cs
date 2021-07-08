using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeUI
{
    public class ProgramUI
    {

        public void Run()
        {
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

        }

        private void AddItemToMenu()
        {

        }

        private void RemoveItemFromMenu()
        {

        }
    }
}
