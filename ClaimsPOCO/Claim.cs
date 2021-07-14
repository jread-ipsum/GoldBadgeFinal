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
        public enum ClaimType { car=1  , home , theft,}
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                var claimAge = DateOfClaim - DateOfIncident;
                if (claimAge.TotalDays <= 30.00)
                {
                    return true;
                }
                return false;
                    
            }
        } 

        public Claim()
        {

        }

        public Claim(ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            this.Type = type;
            this.Description = description;
            this.ClaimAmount = claimAmount;
            this.DateOfIncident = dateOfIncident;
            this.DateOfClaim = dateOfClaim;
        }
    }
}
