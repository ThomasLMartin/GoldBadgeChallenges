using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class CafeRepo
    {
        //This is where to write the CRUD for the MenuItem class
        protected readonly List<MealItem> _menu = new List<MealItem>();
        public bool AddMeaToMenu(MealItem content)
        {
            int initialCount = _menu.Count();
            _menu.Add(content);
            bool wasAdded = initialCount + 1 == _menu.Count();
            return wasAdded;
        }
        public List<MealItem> GetAllMeals()
        {
            return _menu;
        }
        public MealItem GetMealByName(string name)
        {
            foreach (MealItem content in _menu)
            {
                if (content.Name.ToLower() == name.ToLower())
                {
                    return content;
                }
            }
            return null;

        }
        public bool DeleteExistingMenuItems(string name)
        {
            MealItem foundMeal = GetMealByName(name);
            bool deletedResult = _menu.Remove(foundMeal);
            return deletedResult;
        }
    }
}
