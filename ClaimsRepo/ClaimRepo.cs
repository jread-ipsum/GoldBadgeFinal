using ClaimsPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public class ClaimRepo
    {
        private Queue<Claim> _claims = new Queue<Claim>();

        //create
        private int _count;
        public bool AddClaimToQueue(Claim claim)
        {
            if(claim is null)
            {
                return false;
            }
            _count++;
            claim.ClaimID = _count;
            _claims.Enqueue(claim);
            return true;
        }

        //read
        public Queue<Claim> GetAllClaims()
        {
            return _claims;
        }

        public Claim SeeNextClaim()
        {
            return _claims.Peek();
        }

        //delete
        public Claim RemoveClaimFromQueue()
        {
            return _claims.Dequeue();

        }

    }
}
