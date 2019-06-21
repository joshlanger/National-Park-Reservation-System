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
        private ISiteDAO siteDAO;
        //MORE WILL NEED TO BE ADDED TO THE VARIABLE AND CONSTRUCTOR AS YOU PROGRESS!!
        public Menu(IParkDAO parkDAO, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO)
        {
            this.parkDAO = parkDAO;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
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
            string menuChoice = Console.ReadLine().ToUpper();
            if(menuChoice != "1" && menuChoice != "2" && menuChoice != "3" && menuChoice != "Q")
            {
                Console.WriteLine("Invalid Input. Try Again.");
                Console.WriteLine();
                ViewParks();
            }
            
            if (menuChoice == "Q")
            {
                Environment.Exit(0);
            }
            if (menuChoice == "1")
            {
                menuChoice = "Acadia";
                DisplayParkInfo(menuChoice);
            }
            if (menuChoice == "2")
            {
                menuChoice = "Arches";
                DisplayParkInfo(menuChoice);
            }
            if (menuChoice == "3")
            {
                menuChoice = "Cuyahoga Valley";
                DisplayParkInfo(menuChoice);
            }

        }
        public void DisplayParkInfo(string menuChoice)
        {
            chosenPark = menuChoice;
            Park nationalPark = new Park();
            nationalPark = parkDAO.ListInfo(menuChoice);
            Console.WriteLine($"{nationalPark.Name} National Park");
            Console.WriteLine($"Location: {nationalPark.Location}");
            Console.WriteLine($"Established: {nationalPark.EstablishedDate}");
            Console.WriteLine($"Area: {nationalPark.Area}");
            Console.WriteLine($"Annual Visitors: {nationalPark.Visitors}");
            Console.WriteLine();
            Console.WriteLine($"{nationalPark.Description}");
            Console.WriteLine();
            ViewCampgrounds();
        }

        public void ViewCampgrounds()

        {
            Console.WriteLine();
            Console.WriteLine("Select a Command");
            Console.WriteLine("1) View Campgrounds");
            Console.WriteLine("2) Search for Reservations");
            Console.WriteLine("3) Return to Previous Screen");
            Console.WriteLine();
            string menuCampChoice = Console.ReadLine();
            Console.WriteLine();
            
            if (menuCampChoice != "1" && menuCampChoice != "2" && menuCampChoice != "3")
            {
                Console.WriteLine("Invalid Input. Try Again.");
                
                ViewCampgrounds();
            }
                if (menuCampChoice == "1")
            {

                List<Campground> ParkCampgrounds = new List<Campground>();
                ParkCampgrounds = campgroundDAO.CampgroundListInfo(chosenPark);
                Console.WriteLine($" \t {chosenPark} National Park Campgrounds");
                Console.WriteLine();
                Console.WriteLine(" ".PadRight(5) + "Name".PadRight(35) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Fee");
                foreach (var campground in ParkCampgrounds)
                {
                    Console.WriteLine(campground);
                }
                Console.WriteLine();
                while (true)
                {
                    Console.WriteLine("Select a Command");
                    Console.WriteLine("1) Search for Reservation");
                    Console.WriteLine("2) Return to Previous Screen");
                    string userCommand = Console.ReadLine();
                    if (userCommand == "1")
                    {
                        SearchAvailability();
                    }
                    if (userCommand == "2")
                    {
                        ViewCampgrounds();
                    }
                    if (userCommand != "1" || userCommand != "2")
                    {
                        Console.WriteLine("Invalid Input. Try Again.");
                        Console.WriteLine();
                    }
                }
            }
            if (menuCampChoice == "2")
            {
                SearchAvailability();
            }
            if (menuCampChoice == "3")
            {
                ViewParks();
            }
            
            Console.ReadLine();
        }
        public void SearchAvailability()
        {
            Console.WriteLine("");
        }
    }
}
