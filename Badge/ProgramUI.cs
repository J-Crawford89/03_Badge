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
            Badge badgeOne = new Badge(0001, new List<string>() { "A1", "A2", "A3" });
            Badge badgeTwo = new Badge(0002, new List<string>() { "A1", "A2", "B1", "B2" });
            Badge badgeThree = new Badge(0003, new List<string>() { "A3", "B3" });

            _badgeRepo.AddToDirectory(badgeOne);
            _badgeRepo.AddToDirectory(badgeTwo);
            _badgeRepo.AddToDirectory(badgeThree);
        }
        public void RunMenu()
        {

        }
    }
}
