using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MealItem
    {
        //field
        private double _price;
        private int _mealNumber;

        //constructor
        public MealItem() { }
        public MealItem(double dollars, string name, string description, int
            mealNumber, string listOfIngredients)
        {
            Name = name;
            Description = description;
            ListOfIngredients = listOfIngredients;
            SetPrice(dollars);
            SetMealNumber(mealNumber);
        }

        //property
        public string Name { get; set; }
        public double Price
        {
            get
            {
                return _price;
            }
        }
        public string Description { get; set; }
        public int MealNumber
        {
            get
            {
                return _mealNumber;
            }
        }
        public string ListOfIngredients { get; set; }

        //method
        public void SetPrice (double dollars)
        {
            _price = dollars;
        }
        public void SetMealNumber (int mealNumber)
        {
            _mealNumber = mealNumber;
        }
    }
}
