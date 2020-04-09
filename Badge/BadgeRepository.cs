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
    }
}
