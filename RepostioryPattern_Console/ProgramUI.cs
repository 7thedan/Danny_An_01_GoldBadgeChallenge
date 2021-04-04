using RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepostioryPattern_Console
{
    class ProgramUI
    {
        //field
        private MenuContentRepository _menuRepo = new MenuContentRepository();
        //Method that runs/starts the application
        public void Run()
        {
            SeedMenuList();
            Order();
        }

        //Menu
        private void Order()
        {

            bool keepRunning = true;
            while (keepRunning)
            {

                //Display our options to the user.
                Console.WriteLine("Select a Food from the Menu:\n" +
                    "1. Create New Item\n" +
                    "2. View All Items in the Menu\n" +
                    "3. View Items by Name\n" +
                    "4. Update Existing Items on the Menu\n" +
                    "5. Delete Existing Items on the Menu\n" +
                    "6. Exit Menu ");
                //Get the user's input
                string input = Console.ReadLine();

                


                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //create mew
                        CreateNewMenu();
                        break;
                    case "2":
                        //view all
                        DisplayAllMenu();
                        break;
                    case "3":
                        //View Items by name
                        DisplayMenuByName();
                        break;
                    case "4":
                        // update items
                        UpdateExistingMenu();
                        break;
                    case "5":
                        //delete items
                        DeleteExistingMenu();
                        break;
                    case "6":
                        // exit menu
                        Console.WriteLine("Thanks for dining in. Come again!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //create new strung content
        private void CreateNewMenu()
        {
            Console.Clear();
            MenuContent newMenu = new MenuContent();

            //Meal Number
            Console.WriteLine("Enter a number you want for this food item");
            string mealNumber = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumber);

            //Meal name
            Console.WriteLine("Enter the name of the meal");
            newMenu.Name = Console.ReadLine().ToLower();

            //a price.
            Console.WriteLine("Enter a price for the item for the menu: ");
            string price = Console.ReadLine();
            newMenu.Price = double.Parse(price);

            //A description
            Console.WriteLine("Enter the description of the Item: ");
            string description = Console.ReadLine().ToLower();
            //A list of ingredients

            //ingredients
            Console.WriteLine("Enter ingredients of the item: ");
            string ingredints = Console.ReadLine().ToLower();

            Console.WriteLine("Enter a Meal Numbern: \n" +
                "1. Sandwitch\n" +
                "2. Soup\n" +
                "3. Coffee\n" +
                "4. Muffin\n" +
                "5. Cake");

            string foodAsString = Console.ReadLine();
            int foodAsInt = int.Parse(foodAsString);
            newMenu.FoodType = (TypesOfFood)foodAsInt; //casting

            _menuRepo.AddFoodToMenu(newMenu);
            
        }

        //View current menucontent that is saved. See anything that is currently saved.

        private void DisplayAllMenu()
        {
            Console.Clear();

            List<MenuContent> listOfMenu = _menuRepo.ReturnMenuList();

            foreach(MenuContent menu in listOfMenu)
            {
                Console.WriteLine($"{menu.Name}\n" +
                    $", Desc: {menu.Ingredients}\n");

            }
        }
        private void DisplayMenuByName()
        {
            Console.Clear();

            //Prompt the user to give a title 
            Console.WriteLine("Enter the Name of the Menu you like to see: ");

            //Get the user's input
            string name = Console.ReadLine();

            //Find the content by that title
            MenuContent menu =_menuRepo.GetMenuByName(name);

            //Display said content if it isn't null
            if(menu != null) 
            {
                Console.WriteLine($"Food is {menu.Name}\n" +
                   $", Desc: {menu.Ingredients}\n" +
                   $"Meal number: {menu.MealNumber}\n" +
                   $"Price: {menu.Price}\n" +
                   $"Description: {menu.Description}\n" +
                   $"Ingredients: {menu.Ingredients}\n" +
                   $"Food Type: {menu.FoodType}");
            }
            else
            {
                Console.WriteLine("The item was not found by the name");
            }



        }


        //View existing Content by title. 
        private void UpdateExistingMenu()
        {
            DisplayAllMenu();

            //ask for the title
            Console.WriteLine("\n" +
                "Enter the item of the menu you'd like to update");

            //all ask the item of the menu to update.
            string oldMenu = Console.ReadLine();


            //get that title.
            Console.Clear();
            MenuContent newMenu = new MenuContent();

            //Meal Number
            Console.WriteLine("Enter a number you want for this food item");
            string mealNumber = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumber);

            //Meal name
            Console.WriteLine("Enter the name of the meal");
            newMenu.Name = Console.ReadLine().ToLower();

            //a price.
            Console.WriteLine("Enter a price for the item for the menu: ");
            string price = Console.ReadLine();
            newMenu.Price = double.Parse(price);

            //A description
            Console.WriteLine("Enter the description of the Item: ");
            string description = Console.ReadLine().ToLower();
            //A list of ingredients

            //ingredients
            Console.WriteLine("Enter ingredients of the item: ");
            string ingredints = Console.ReadLine().ToLower();

            Console.WriteLine("Enter a Meal Numbern: \n" +
                "1. Sandwitch\n" +
                "2. Soup\n" +
                "3. Coffee\n" +
                "4. Muffin\n" +
                "5. Cake");

            string foodAsString = Console.ReadLine();
            int foodAsInt = int.Parse(foodAsString);
            newMenu.FoodType = (TypesOfFood)foodAsInt; //casting


            //verify the update worked
            bool wasUpdated = _menuRepo.UpdateExisitingMenu(oldMenu, newMenu);

            if (wasUpdated)
            {
                Console.WriteLine("Menu was successfully updated!");
            }
            else
            {
                Console.WriteLine("Sorry, could not be updated");
            }
 
        }

        //Delete Existing Menu
        private void DeleteExistingMenu()
        {
            
            DisplayAllMenu();

            //Get the name we want to remove 
            Console.WriteLine("\n" +
                "Enter which menu item would you like to remove?");

            //call the delete method
            string input = Console.ReadLine();

            //if the content was deleted, say so
           bool wasDeleted = _menuRepo.RemoveFoodFromMenu(input);
            if (wasDeleted) 
            {
                Console.WriteLine("The menu item was successfully deleted");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted");
            }

            //otherwise state it could not be deleted

          

        }

        //See method
        private void SeedMenuList()
        {
            MenuContent realpistachiocupcakes = new MenuContent(1, "Real Pistachio Cupcake", 2.99, "roasted pistachio nut meatsm", 
                " 1 & 1/2 cups white sugar\n" +
                ", 3/4 flour, 2 teaspoons baking powder\n" +
                ", 3/4 salt, unsalted butter\n" +
                ", 4 large egg\n" +
                ", 2/4 cup of mlk\n" +
                ", 2 teaspoon of vanilla", TypesOfFood.Muffins);
            MenuContent americanos = new MenuContent(2, "Columbian Coffee", 3.99, "dark coffee", "Coffee beans from Columbia finely roasted",TypesOfFood.Coffee);
            MenuContent cookiesandcreamcake = new MenuContent(3, "Cookies & Cream Cake", 5.99, "oreos cookies mashed with ice cream","24 Vanilla ice crea\n" +
                ", 2 crushed oreo cookies\n" +
                ", 1 jar hot fudge ice cream\n" +
                ", 1 jar caramel ice cream topping\n" +
                ", and chopped peacans", TypesOfFood.Cake);
            MenuContent clamcowder = new MenuContent(4, "Clam Chowder Soup", 4.50, "A warm soup with clams and potatoes and other vegetables", 
                "1 Cup minced Onion\n" +
                ", Celery, Potatoes\n" +
                ", 1 Cup of diced Carrots\n" +
                ", 1 Cup of Clams\n" +
                ", and 1 quarter of half and half milk", TypesOfFood.Soup);
            MenuContent blt = new MenuContent(5, "BLT", 7.99, "Filled with meat and vegetables for the meat lovers!","4 slice of bacon\n" +
                "2 leaves lettuce \n" +
                "4 slices of baloney \n" +
                "2 slices of tomatoes \n" +
                "2 slice bread, toasted \n" +
                "1 tablespoon of mayonnaise", TypesOfFood.Sandwitch);

            _menuRepo.AddFoodToMenu(realpistachiocupcakes);
            _menuRepo.AddFoodToMenu(americanos);
            _menuRepo.AddFoodToMenu(cookiesandcreamcake);
            _menuRepo.AddFoodToMenu(clamcowder);
            _menuRepo.AddFoodToMenu(blt);




        }
    }
}
