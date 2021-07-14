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
        private Badge _badge;
        private Badge _badge2;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(1, new List<string> { "A1","A2","B1","B2"});

            _repo.AddBadgeToDict(_badge);
        }


            

        [TestMethod]
        public void AddBadgeToDict_ShouldNotGetNull()
        {

        }
    }
}
