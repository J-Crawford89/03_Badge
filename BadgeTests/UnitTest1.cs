using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Badge03;

namespace BadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        Badge badgeOne = new Badge();
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBool()
        {
            bool wasAdded = _badgeRepo.AddToDirectory(badgeOne);

            Assert.IsTrue(wasAdded);
        }
    }
}
