using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimClass
{
    public class ClaimsRepo
    {
        protected readonly Queue<Claims> claimsDirectory = new Queue<Claims>();
        public bool AddClaimToDirectory(Claims content)
        {
            int initialCount = claimsDirectory.Count();
            claimsDirectory.Enqueue(content);
            bool wasAdded = initialCount + 1 == claimsDirectory.Count();
            return wasAdded;
        }
        public Queue<Claims> GetAllClaims()
        {
            return claimsDirectory;
        }
        public Claims GetNextClaim()
        {
            return claimsDirectory.Peek();
        }
        public bool RemoveCurrentClaim()
        {
            int initialCount = claimsDirectory.Count();          
            claimsDirectory.Dequeue();
            bool wasRemoved = initialCount - 1 == claimsDirectory.Count();
            return wasRemoved;
        }
    }
}
