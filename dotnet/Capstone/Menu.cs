using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;



namespace Capstone
{
    public class Menu
    {
        private IParkDAO parkDAO;
        //MORE WILL NEED TO BE ADDED TO THE VARIABLE AND CONSTRUCTOR AS YOU PROGRESS!!
        public Menu(IParkDAO parkDAO)
        {
            this.parkDAO = parkDAO;
        }

        
        public void Intro()
        {
            Console.WriteLine("Welcome to the National Park Service reservation system.");
            Console.WriteLine();
        }
        public void ViewParks()
        {
            Console.WriteLine("Select a Park for Further Details");
            Console.WriteLine("1) Acadia");
            Console.WriteLine("2) Arches");
            Console.WriteLine("3) Cuyahoga National Valley Park");
            Console.WriteLine("Q) Quit");
            Console.WriteLine();
            string menuChoice = Console.ReadLine();
            if(menuChoice == "1")
            {
                menuChoice = "'Acadia'";
                parkDAO.ListInfo(menuChoice);
               
            }
            if(menuChoice == "2")
            {
                menuChoice = "'Arches'";

            }
            if(menuChoice == "3")
            {
                menuChoice = "Cuyahoga Valley";
            }
            Console.ReadLine();
        }
        
    }
}
