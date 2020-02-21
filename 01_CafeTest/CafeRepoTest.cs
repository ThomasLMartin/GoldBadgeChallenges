using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeRepoTest
    {
        [TestMethod]
        public void AddToMenu()
        {
            MealItem content = new MealItem();
            CafeRepo repository = new CafeRepo();
            bool addResult = repository.AddMealToMenu(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenu_ShouldReturnCorrectMeal()
        {
            MealItem content = new MealItem();
            CafeRepo repo = new CafeRepo();
            repo.AddMealToMenu(content);
            List<MealItem> contents = repo.GetAllMeals();
            bool menuHasMeal = contents.Contains(content);
            Assert.IsTrue(menuHasMeal);
        }
        private MealItem _content;
        private CafeRepo _repo;
        [TestInitialize]
        public void Arragne()
        {
            _repo = new CafeRepo();
            _content = new MealItem(5.99, "CheeseBurger", "100% Angus Beef with Cheader Cheese", 2, "Angus Beef, Tomato, Lettus, Cheader Chesse, Onion, Pickle, Mayo");
            _repo.AddMealToMenu(_content);
        }
        [TestMethod]
        public void MenuTest()
        {
            bool removeMeal = _repo.DeleteExistingMenuItems("CheeseBurger");
            Assert.IsTrue(removeMeal);
        }
    }
}
