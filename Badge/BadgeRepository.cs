using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge03
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();

        public bool AddToDirectory(Badge badgeToAdd)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(badgeToAdd.BadgeID, badgeToAdd.DoorNames);

            return startingCount < _badgeDirectory.Count;
        }
        public int GetCout()
        {
            return _badgeDirectory.Count;
        }
        public List<string> GetBadgeByNumber(int badgeNumber)
        {
            return _badgeDirectory[badgeNumber];
        }
        public void UpdateDoorsByBadgeNumber(int badgeNumber, List<string> newDoors)
        {
            _badgeDirectory[badgeNumber] = newDoors;
        }
        public void ListAllBadges()
        {
            Console.WriteLine($"{"Badge ID", -8}|Door Access\n" +
                $"---------------------------------------");
            foreach(KeyValuePair<int, List<string>> badge in _badgeDirectory)
            {
                int badgeNumber = badge.Key;
                List<string> listOfDoors = badge.Value;
                string doors = string.Join(", ", listOfDoors);
                Console.WriteLine($"{badgeNumber, -8}|{doors}");
            }
            Console.ReadLine();
        }
    }
}
