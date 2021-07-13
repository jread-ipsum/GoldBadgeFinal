using ClaimsPOCO;
using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaims();
            AppMenu();
        }

        private void AppMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("=======Komodo Claims Department=======\n");
                Console.WriteLine("Select an option:\n" +
                    "1.See all claims.\n" +
                    "2.Take care of next claim.\n" +
                    "3.Enter new claim.\n" +
                    "4. Exit\n");

                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("======Claims Queue=======\n");
            Console.WriteLine("ClaimID Type Description    Amount  DateOfAccident DateOfClaim IsValid");

            Queue<Claim> claims = _claimRepo.GetAllClaims();
            foreach(Claim claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID}      {claim.Type}  {claim.Description}   {claim.ClaimAmount}  {claim.DateOfIncident}  {claim.DateOfClaim}  {claim.IsValid}");
            }
        }

        private void NextClaim()
        {
            Console.Clear();
            Claim peekClaim = _claimRepo.SeeNextClaim();
            Console.WriteLine($"ClaimID:{peekClaim.ClaimID}\n" +
                $"Type: {peekClaim.Type}\n" +
                $"Description: {peekClaim.Description}\n" +
                $"Amount: {peekClaim.ClaimAmount}\n" +
                $"Date of Accident: {peekClaim.DateOfIncident}\n" +
                $"Date of Claim: {peekClaim.DateOfClaim}\n" +
                $"IsValid: {peekClaim.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            var dealNow = Console.ReadLine();
            if(dealNow is "y")
            {
                _claimRepo.RemoveClaimFromQueue();
            }
        }

        private void NewClaim()
        {
            Claim newClaim = new Claim();

            Console.Clear();
            Console.WriteLine("Enter the claim type:\n" +
                "Enter 1 for car.\n" +
                "Enter 2 for home.\n" +
                "Enter 3 for theft.\n");
            int inputClaimType = int.Parse(Console.ReadLine());
            Claim.ClaimType claimType = (Claim.ClaimType)inputClaimType;

            
        }

        private void SeedClaims()
        {
            Claim claim1 = new Claim(Claim.ClaimType.car, "Car accident on 465", 400.00, new DateTime(18,4,25), new DateTime(18, 4, 27), true);
            Claim claim2 = new Claim(Claim.ClaimType.home, "House fire in kitchen", 4000.00, new DateTime(18,4,11), new DateTime(18, 4, 12), true);
            Claim claim3 = new Claim(Claim.ClaimType.theft, "Stolen pancakes.", 4.00, new DateTime(18,4,27), new DateTime(18, 6, 01), false);

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
        }
    }
}
