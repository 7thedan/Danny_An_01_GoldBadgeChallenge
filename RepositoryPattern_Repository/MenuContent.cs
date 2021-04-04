using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public enum TypesOfFood
    {
      Sandwitch =1,
      Soup,
      Coffee,
      Muffins,
      Cake
    }
    public class MenuContent
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }

        public TypesOfFood FoodType { get; set; }

        public MenuContent() { }

        public MenuContent(int mealnumber, string name, double price, string description, string ingredients, TypesOfFood Items)
        {
            MealNumber = MealNumber;
            Name = name;
            Price = price;
            Description = description;
            Ingredients = ingredients;
            FoodType = Items;

        }

 
    }

   
}
