using System;
using System.Collections.Generic;
using System.Text;



namespace Capstone
{
    public class Menu
    {
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
        }
    }
}
