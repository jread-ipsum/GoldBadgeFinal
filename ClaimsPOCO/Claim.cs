using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsPOCO
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public enum ClaimType { car, home, theft, }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid() 
        {
            if(claimAge <= TimeSpan(30, 0, 0, 0)
        }

        private TimeSpan claimAge = 

        public Claim()
        {

        }

        public Claim(ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {

        }

        public Claim(TimeSpan claimAge, TimeSpan claimLimit)
        {
            claimAge = DateOfClaim - DateOfIncident;
            claimLimit = TimeSpan(30, 0, 0, 0);
        }
    }
}
