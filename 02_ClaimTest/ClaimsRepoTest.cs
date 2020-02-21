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
        public void IsValid()
        {

        }
    }
}
