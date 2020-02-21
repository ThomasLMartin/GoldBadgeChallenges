using _02_ClaimClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_ClaimClass.Claims;

namespace _02_ClaimConsole
{
    public class ClaimUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        private IClaims _console;
        public ClaimUI(IClaims console)
        {
            _console = console;
        }
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool contiuneToRun = true;
            while (contiuneToRun)
            {
                _console.Clear();
                _console.WriteLine("Select a Number: \n" +
                    "1. Display all Claims\n" +
                    "2. Take care of next Claim\n" +
                    "3. Enter a new Claim\n" +
                    "4. Exit");
                string userInput = _console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();
                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "5":
                        contiuneToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddNewClaim()
        {
            Claims content = new Claims();
            _console.WriteLine("Enter the ClaimID");
            int ClaimID = int.Parse(_console.ReadLine());

            _console.WriteLine("Enter the claim type");
            string ClaimType = _console.ReadLine();
            int TypeOfClaim = int.Parse(ClaimType);
            content.TypeOfClaim = (ClaimType)TypeOfClaim;


            _console.WriteLine("Enter a claim description");
            content.Description = _console.ReadLine();

            _console.WriteLine("Ammount of Damage");
            int ClaimAmmount = int.Parse(_console.ReadLine());

            _console.WriteLine("Date Of Accident");
            DateTime DateOfIncident = DateTime.Parse(_console.ReadLine());

            _console.WriteLine("Date of Claim");
            DateTime DateOfClaim = DateTime.Parse(_console.ReadLine());

            _claimsRepo.AddClaimToDirectory(content);
            _console.WriteLine("Your claim has been added. Press any key to return to main menu");
            _console.ReadKey();

        }
        private void DisplayAllClaims()
        {
            _console.Clear();
            Queue<Claims> claims = new Queue<Claims>();
            claims = _claimsRepo.GetAllClaims();
            foreach (Claims content in claims)
            {
                _console.WriteLine($"{content.ClaimID}\n" +
                    $"{content.TypeOfClaim}\n" +
                    $"{content.Description}\n" +
                    $"{content.ClaimAmmount}\n" +
                    $"{content.DateOfIncident}\n" +
                    $"{content.DateOfClaim}\n");
            }
            _console.WriteLine("Press any key to contiune...");
            _console.ReadKey();
        }
        private void DequeueContent()
        {
            Console.Clear();
            Queue<Claims> current = _claimsRepo.GetAllClaims();
            if (current.Count > 0)
            {
                Claims peekClaim = current.Peek();
                Console.WriteLine("Here is the next queued claim.");
                Console.WriteLine($"{peekClaim.ClaimID,-25}{peekClaim.TypeOfClaim,-25}{peekClaim.Description,-25}${peekClaim.ClaimAmmount,-10}{peekClaim.DateOfIncident,-25}" +
                    $"{peekClaim.DateOfClaim,-32}{peekClaim.IsValid,-25}\n");
                Console.WriteLine("Would you like to proceed with this claim?\n" +
                    "1. Yes\n" +
                    "2. No");
                string peek = Console.ReadLine();
                peek = peek.Replace(" ", "");
                peek = peek.Trim();
                switch (peek)
                {
                    case "1":
                        current.Dequeue();
                        Console.WriteLine("This claim has been removed from the queue.\n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "2":
                        break;
                }
            }
            else
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private void SeedContent()
        {
            Claims firstClaim = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claims secondClaim = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims thirdClaim = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 18));

        }
    }
}
