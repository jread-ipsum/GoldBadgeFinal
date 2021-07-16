using BadgesPOCO;
using BadgesRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesUI
{
    public class BadgesUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            AppMenu();
        }

        private void AppMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("==============Komodo Badging System===============");
                Console.WriteLine("Select an option:\n" +
                    "1.Add a badge\n" +
                    "2.Edit a badge\n" +
                    "3.List all badges\n" +
                    "4.Exit app\n");

                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("\npress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddBadge()
        {
            Console.WriteLine("What is the number on the badge?");
            var badgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to.");
            var door = Console.ReadLine();

            List<string> doors = new List<string>();
            doors.Add(door);

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.Clear();
                Console.WriteLine("Would you like to add more doors(y/n)?");
                var inputCommand = Console.ReadLine();

                if (inputCommand is "y")
                {
                    Console.WriteLine("List a door this it needs access to.");
                    var newDoor = Console.ReadLine();
                    doors.Add(newDoor);
                }
                else
                {
                    Console.WriteLine("Door(s) have been added to list.");
                    addingDoors = false;
                }
            }
            Badge newBadge = new Badge(badgeId, doors);
            bool isSuccessful = _badgeRepo.AddBadgeToDict(newBadge);
            if (isSuccessful)
            {
                Console.WriteLine("Badge has been added to database!");
            }
            else
            {
                Console.WriteLine("Badge could not be added to database.");
            }

        }

        private void EditBadge()
        {

        }

        private void ListAllBadges()
        {

        }
    }
}
