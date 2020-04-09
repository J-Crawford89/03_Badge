using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge03
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedBadges();
            RunMenu();
        }
        public void SeedBadges()
        {
            Badge badgeOne = new Badge(1001, new List<string>() { "A1", "A2", "A3" });
            Badge badgeTwo = new Badge(1002, new List<string>() { "A1", "A2", "B1", "B2" });
            Badge badgeThree = new Badge(1003, new List<string>() { "A3", "B3" });

            _badgeRepo.AddToDirectory(badgeOne);
            _badgeRepo.AddToDirectory(badgeTwo);
            _badgeRepo.AddToDirectory(badgeThree);
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do? Please select a number.\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.Clear();
                        bool wasAdded = AddBadge();
                        if (wasAdded)
                        {
                            Console.WriteLine("Badge added successfully");
                        }
                        else
                        {
                            Console.WriteLine("Badge not added. Please try again.");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        UpdateBadge();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        _badgeRepo.ListAllBadges();
                        Console.Clear();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private bool AddBadge()
        {
            Badge newBadge = new Badge();
            Console.Write("Enter badge number: ");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());
            List<string> listOfDoors = new List<string>();
            Console.Write("Enter a door this badge will have access to: ");
            listOfDoors.Add(Console.ReadLine().ToUpper());
            bool moreDoors = true;
            while (moreDoors)
            {
                Console.Write("Does this badge need access to any other doors(y/n)? ");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "y":
                    case "yes":
                        Console.Write("Enter a door this badge will have access to: ");
                        listOfDoors.Add(Console.ReadLine().ToUpper());
                        break;
                    case "n":
                    case "no":
                        moreDoors = false;
                        break;
                    default:
                        break;
                }
            }
            newBadge.DoorNames = listOfDoors;
            return _badgeRepo.AddToDirectory(newBadge);
        }
        private void UpdateBadge()
        {
            Console.Write("Please enter the badge number to update: ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            List<string> listOfDoors = _badgeRepo.GetBadgeByNumber(badgeNumber);
            if (listOfDoors.Count > 0)
            {
                bool updatingBadge = true;
                while (updatingBadge)
                {
                    Console.WriteLine($"Badge number {badgeNumber} has access to the following doors:\n");
                    for (int i = 0; i < listOfDoors.Count; i++)
                    {
                        Console.WriteLine(listOfDoors[i]);
                    }
                    Console.WriteLine("\n\nWhat would you like to do? Please select a number.\n" +
                        "1. Remove a door\n" +
                        "2. Add a door\n" +
                        "3. Exit\n\n");
                    string response = Console.ReadLine();
                    switch (response)
                    {
                        case "1":
                            Console.Write("Which door would you like to remove? ");
                            listOfDoors.Remove(Console.ReadLine().ToUpper());
                            Console.Clear();
                            break;
                        case "2":
                            Console.Write("Which door would you like to add? ");
                            listOfDoors.Add(Console.ReadLine().ToUpper());
                            Console.Clear();
                            break;
                        case "3":
                            updatingBadge = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                _badgeRepo.UpdateDoorsByBadgeNumber(badgeNumber, listOfDoors);
            }
            else
            {
                Console.WriteLine("Invalid badge number. Please try again.");
            }
        }
    }
}
