using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePOCO
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(string mealName, string description, string ingredients, double price)
        {
            this.MealName = mealName;
            this.Description = description;
            this.Ingredients = ingredients;
            this.Price = price;
        }

    }
}
