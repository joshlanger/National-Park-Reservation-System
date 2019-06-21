using Capstone.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");
            IParkDAO parkDAO = new ParkSqlDAO(@"Server =.\SQLEXPRESS; Database = npcampground; Trusted_Connection = True;");
            ICampgroundDAO campgroundDAO = new CampgroundSqlDAO(@"Server =.\SQLEXPRESS; Database = npcampground; Trusted_Connection = True;");
            //ISiteDAO siteDAO = new SiteSqlDAO(@"Server =.\SQLEXPRESS; Database = npcampground; Trusted_Connection = True;");
            Menu menus = new Menu(parkDAO, campgroundDAO);
            //MORE WILL NEED TO BE ADDED TO THIS CONSTRUCTOR AS YOU PROGRESS!!!
            menus.Intro();
            menus.ViewParks();
            menus.ViewCampgrounds();
        }
    }
}
