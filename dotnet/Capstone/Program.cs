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
            Menu menus = new Menu();
            menus.Intro();
            menus.ViewParks();
        }
    }
}
