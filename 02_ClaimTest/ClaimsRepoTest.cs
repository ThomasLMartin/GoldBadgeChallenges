using System;
using System.Collections.Generic;
using _02_ClaimClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _02_ClaimClass.Claims;

namespace _02_ClaimTest
{
    [TestClass]
    public class ClaimsRepoTest
    {
        [TestMethod]
        public void AddToClaims()
        {
            Claims content = new Claims();
            ClaimsRepo repository = new ClaimsRepo();
            bool addResult = repository.AddClaimToDirectory(_content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaim_ShouldReturnCorrectClaim()
        {
            Claims content = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToDirectory(content);
            Queue<Claims> contents = repo.GetAllClaims();
            bool claimHasContent = contents.Contains(content);
            Assert.IsTrue(claimHasContent);
        }
        private Claims _content;
        private ClaimsRepo _repo;
        [TestMethod]
        public void TestTimeLapse_ShouldReturnFalse()
        {
            Claims newClaim = new Claims();
            DateTime personalClaim = new DateTime();
            DateTime incidentDate = new DateTime();
            personalClaim = new DateTime(2020, 02, 18);
            incidentDate = new DateTime(2019, 12, 18);
            TimeSpan dayslapsed = personalClaim - incidentDate;
            double totalDays = dayslapsed.TotalDays;
            Assert.IsTrue(totalDays > 30);
        }
    }
}
