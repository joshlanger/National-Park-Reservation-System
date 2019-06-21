using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;



namespace Capstone
{
    public class Menu
    {
        public string chosenPark = "";
        private IParkDAO parkDAO;
        private ICampgroundDAO campgroundDAO;
        //MORE WILL NEED TO BE ADDED TO THE VARIABLE AND CONSTRUCTOR AS YOU PROGRESS!!
        public Menu(IParkDAO parkDAO, ICampgroundDAO campgroundDAO)
        {
            this.parkDAO = parkDAO;
            this.campgroundDAO = campgroundDAO;
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
            Park nationalPark = new Park();
            string menuChoice = Console.ReadLine();
            if(menuChoice == "Q" || menuChoice == "q")
            {
                return;
            }
            if(menuChoice == "1")
            {
                menuChoice = "Acadia";
                chosenPark = menuChoice;
                nationalPark = parkDAO.ListInfo(menuChoice);
                DisplayParkInfo(nationalPark);
               
            }
            if(menuChoice == "2")
            {
                menuChoice = "Arches";
                chosenPark = menuChoice;
                nationalPark = parkDAO.ListInfo(menuChoice);
                DisplayParkInfo(nationalPark);
            }
            if(menuChoice == "3")
            {
                menuChoice = "Cuyahoga Valley";
                chosenPark = menuChoice;
                nationalPark = parkDAO.ListInfo(menuChoice);
                DisplayParkInfo(nationalPark);
            }
            Console.ReadLine();
        }
        public void DisplayParkInfo(Park nationalPark)
        {
            Console.WriteLine($"{nationalPark.Name} National Park");
            Console.WriteLine($"Location: {nationalPark.Location}");
            Console.WriteLine($"Established: {nationalPark.EstablishedDate}");
            Console.WriteLine($"Area: {nationalPark.Area}");
            Console.WriteLine($"Annual Visitors: {nationalPark.Visitors}");
            Console.WriteLine();
            Console.WriteLine($"{nationalPark.Description}");
        }

        public void ViewCampgrounds()
        {
            Console.WriteLine("Select a Command");
            Console.WriteLine("1) View Campgrounds");
            Console.WriteLine("2) Search for Reservations");
            Console.WriteLine("3) Return to Previous Screen");
            Console.WriteLine();
            string menuCampChoice = Console.ReadLine();
            if (menuCampChoice == "1")
            {
                //Console.WriteLine("Acadia National Park Campgrounds");
                //menuCampChoice = "'1'";
                List<Campground> ParkCampgrounds = new List<Campground>();
                ParkCampgrounds = campgroundDAO.CampgroundListInfo(chosenPark);
                foreach(var campground in ParkCampgrounds)
                {
                    Console.WriteLine(campground);
                }
            }
            if (menuCampChoice == "2")
            {
                Console.WriteLine("Arches National Park Campgrounds");
                menuCampChoice = "'2'";

            }
            if (menuCampChoice == "3")
            {
                Console.WriteLine("Cuyahoga Valley National Park Campgrounds");
                menuCampChoice = "'3'";
            }


            Console.ReadLine();
        }
    }
}
