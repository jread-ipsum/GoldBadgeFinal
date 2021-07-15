using BadgesPOCO;
using BadgesRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgesUnitTest
{
    [TestClass]
    public class BadgesRepoTests
    {
        private BadgeRepo _repo;
        private Badge badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            badge = new Badge(1, new List<string> { "A1","A2","B1","B2"});

            _repo.AddBadgeToDict(badge);
        }

        [TestMethod]
        public void AddBadgeToDict_DoesNotContainKey_ReturnTrue()
        {
            Badge badge2 = new Badge(2, new List<string> { "A1", "A2", "B1", "B2" });

            bool result = _repo.AddBadgeToDict(badge2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBadgeToDict_AlreadyContainsKey_ReturnFalse()
        {
            Badge badge2 = new Badge(1, new List<string> { "A1", "A2", "B1", "B2" });

            bool result = _repo.AddBadgeToDict(badge2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
