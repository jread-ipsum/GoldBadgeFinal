using ClaimsPOCO;
using ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsUnitTest
{
    [TestClass]
    public class ClaimRepoUnitTests
    {
        private readonly ClaimRepo _repo = new ClaimRepo();

        [TestInitialize]
        public void Arrange()
        {
            DateTime incident = new DateTime(2021, 8, 15);
            DateTime claimDate = new DateTime(2021, 7, 20);
            Claim claim = new Claim(Claim.ClaimType.car, "wreck", 200.00, incident, claimDate, true);
            _repo.AddClaimToQueue(claim);
        }

        [TestMethod]
        public void AddClaimToQueue_ClaimIsNull_ReturnFalse()
        {
            Claim claim = null;
            ClaimRepo repo = new ClaimRepo();

            bool result = repo.AddClaimToQueue(claim);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddClaimToQueue_ClaimIsNotNull_ReturnTrue()
        {
            DateTime incident = new DateTime(2021, 8, 15);
            DateTime claimDate = new DateTime(2021, 7, 20);
            Claim claim = new Claim(Claim.ClaimType.car, "wreck", 200.00, incident, claimDate, true);

            bool result = _repo.AddClaimToQueue(claim);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveClaimFromQueue_ClaimDequeued()
        {
            Claim result = _repo.RemoveClaimFromQueue();
            Assert.IsNotNull(result);
        }
    }
}
