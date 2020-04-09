using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Badge03;
using System.Collections.Generic;

namespace BadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        Badge badgeOne = new Badge(0001, new List<string>() { "A1", "A2", "A3" });
        Badge badgeTwo = new Badge(0002, new List<string>() { "B1", "B2", "B3" });
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBool()
        {
            bool wasAdded = _badgeRepo.AddToDirectory(badgeOne);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetBadgeByNumber_ShouldGetCorrectBadge()
        {
            _badgeRepo.AddToDirectory(badgeOne);
            _badgeRepo.AddToDirectory(badgeTwo);

            string actual = string.Join(",", _badgeRepo.GetBadgeByNumber(0001));
            string expected = "A1,A2,A3";

            Assert.AreEqual(expected, actual);
        }
    }
}
