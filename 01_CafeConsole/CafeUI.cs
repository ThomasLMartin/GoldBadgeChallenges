using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsole
{
    public class CafeUI
    {
        private readonly CafeRepo _cafeRepo = new CafeRepo();
        private ICafe _console;
        public CafeUI(ICafe console)
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
                    "1. Display all Menu Items\n" +
                    "2. Add Menu Items\n" +
                    "3. Update Menu Items\n" +
                    "4. Remove Menu Items\n" +
                    "5. Exit");
                string userInput = _console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();
                switch (userInput)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        AddNewMenuItem();
                        break;
                    case "3":
                        break;
                    case "4":
                        DeleteContent();
                        break;
                    case "5":
                        contiuneToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddNewMenuItem()
        {
            MealItem content = new MealItem();
            _console.WriteLine("Enter Meal's Name");
            content.Name = _console.ReadLine();
            _console.WriteLine("Enter Meal's Description");
            content.Description = _console.ReadLine();
            _console.WriteLine("Enter Meal's Price");
            double SetPrice = double.Parse(_console.ReadLine());
            content.SetPrice(SetPrice);
            _console.WriteLine("Enter Meal's Ingredients");
            content.ListOfIngredients = _console.ReadLine();
            _console.WriteLine("Enter Meal's Number");
            int mealNumber = int.Parse(_console.ReadLine());
            content.SetMealNumber(mealNumber);
            _cafeRepo.AddMealToMenu(content);
            _console.WriteLine("Your meal has been added. Press any key to return to main menu");
            _console.ReadKey();
        }
        private void ShowAllMenuItems()
        {
            _console.Clear();
            List<MealItem> meals = new List<MealItem>();
            meals = _cafeRepo.GetAllMeals();
            foreach(MealItem content in meals)
            {
                _console.WriteLine($"{content.Name}\n" +
                    $"{content.Description}\n" +
                    $"{content.Price}\n" +
                    $"{content.ListOfIngredients}\n" +
                    $"{content.MealNumber}\n");
            }
            _console.WriteLine("Press any key to contiune...");
            _console.ReadKey();
        }
        // Get an object and delete
        private void DeleteContent()
        {
            _console.WriteLine("Enter name of meal you would like to delete:");
            string name = _console.ReadLine();
            MealItem existingContent = _cafeRepo.GetMealByName(name);
            _cafeRepo.DeleteExistingMenuItems(existingContent.Name);
            _console.WriteLine("Your item has been deleted. Press any key to contiune...");
            _console.ReadKey();
        }
        private void SeedContent()
        {
            MealItem hotdog = new MealItem(2.00, "HotDog", "Meat stick that is boiled and placed into a bun", 15, "HotDog, Ketchup, Mustard, Relish, Bun");
            _cafeRepo.AddMealToMenu(hotdog);
        }
    }
}
