using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimClass
{
    public enum ClaimType { Car = 1, Home = 2, Theft = 3 }
    public class Claims
    {
        public Claims() { }
        public Claims(int claimID, ClaimType typeOfClaim, string description, double claimAmmout, DateTime dateOfIncident, DateTime dateOfClaim) 
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmmount = claimAmmout;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan lengthOfDays = DateOfClaim - DateOfIncident;
                int days = Convert.ToInt32(lengthOfDays);
                if (days > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
        }
    }
}