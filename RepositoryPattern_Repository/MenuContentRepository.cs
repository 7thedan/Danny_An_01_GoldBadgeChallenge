using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public class MenuContentRepository
    {
        private List<MenuContent> _listOfMenu = new List<MenuContent>();

        //Create
        public void AddFoodToMenu(MenuContent menu) 
        {
            _listOfMenu.Add(menu);    
        }

        //Read
        public List<MenuContent> ReturnMenuList()
        {
            return _listOfMenu;
        }


        //Update
        public bool UpdateExisitingMenu(string signatureFood, MenuContent newItem)
        {
            // find the menu
            MenuContent oldMenu = GetMenuByName(signatureFood);


            //update the menu
            if(oldMenu != null)
            {
                oldMenu.MealNumber = newItem.MealNumber;
                oldMenu.Name = newItem.Name;
                oldMenu.Price = newItem.Price;
                oldMenu.Description = newItem.Description;
                oldMenu.Ingredients = newItem.Ingredients;
                oldMenu.FoodType = newItem.FoodType;

                //staying in the same menu but updating the menu.

                return true;
            }
            else
            {
                return false;
            }
        }



        //Delete
        public bool RemoveFoodFromMenu(string name)
        {
            MenuContent menu = GetMenuByName(name);
            
            if(menu == null)
            {
                return false;
            }

            int initialCount = _listOfMenu.Count;
            _listOfMenu.Remove(menu);

            if(initialCount > _listOfMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper method
        public MenuContent GetMenuByName(string name)
        {
            foreach (MenuContent menu in _listOfMenu)
            {
                 if(menu.Name.ToLower() == name.ToLower())
                {
                    return menu;
                }
            }

            return null;
        }
    }
}
