using ClaimsPOCO;
using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ClaimsUI
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
                    "4.Exit\n");

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
                Console.WriteLine("\npress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("==========================Claims Queue==========================\n");

            Console.WriteLine($"{"ID",-3}{"Type",-6}{"Description",-25}{"Amount",-8}{"DateAccident",-13}{"DateClaim",-13}{"IsValid",-7}\n");

            Queue<Claim> claims = _claimRepo.GetAllClaims();
            foreach(Claim claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID,-3}{claim.Type,-6}{claim.Description,-25}{claim.ClaimAmount,-8}{claim.DateOfIncident.Date.ToString("d"),-13}{claim.DateOfClaim.Date.ToString("d"),-13}{claim.IsValid,-7}");
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
                $"Date of Accident: {peekClaim.DateOfIncident.Date.ToString("d")}\n" +
                $"Date of Claim: {peekClaim.DateOfClaim.Date.ToString("d")}\n" +
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
            Console.Clear();
            Console.WriteLine("Enter the claim type:\n" +
                "Enter 1 for car.\n" +
                "Enter 2 for home.\n" +
                "Enter 3 for theft.\n");

            int inputClaimType = int.Parse(Console.ReadLine());
            Claim.ClaimType claimType = (Claim.ClaimType)inputClaimType;

            Console.WriteLine("\nEnter a description of the claim.");
            var description = Console.ReadLine();

            Console.WriteLine("\nEnter the claim amount.");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter date of the incident(yyyy,mm,dd)");
            var incidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the date of the claim(yyyy,mm,dd)");
            var claimDate = DateTime.Parse(Console.ReadLine());

            Claim newClaim = new Claim(claimType, description, claimAmount, incidentDate, claimDate);

            bool isSuccessful = _claimRepo.AddClaimToQueue(newClaim);
            if (isSuccessful)
            {
                Console.WriteLine("new claim has been successfully added to Queue.");
            }
            else
            {
                Console.WriteLine("new claim could not be added to Queue.");
            }
        }

        private void SeedClaims()
        {
            Claim claim1 = new Claim(Claim.ClaimType.car, "Car accident on 465", 400.00, new DateTime(18,4,25), new DateTime(18, 4, 27));
            Claim claim2 = new Claim(Claim.ClaimType.home, "House fire in kitchen", 4000.00, new DateTime(18,4,11), new DateTime(18, 4, 12));
            Claim claim3 = new Claim(Claim.ClaimType.theft, "Stolen pancakes.", 4.00, new DateTime(18,4,27), new DateTime(18, 6, 01));

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
        }
    }
}
