using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developers by Teams\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        CreateNewDeveloper();
                        break;
                    case "2":
                    case "two":
                        ViewAllDevelopers();
                        break;
                    case "3":
                    case "three":
                        ViewDevelopersByTeams();
                        break;
                    case "4":
                    case "four":
                        //UpdateExistingDeveloper
                        break;
                    case "5":
                    case "five":
                        //DeleteExistingDeveloper
                        break;
                    case "6":
                    case "six":
                        //exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("What is the developer ID?");
            newDev.DevID = (Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("What is the developer's First Name?");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("What is the developer's Last Name?");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Does the developer have Pluralsight?");
            string hasPluralsight = Console.ReadLine();
            hasPluralsight.ToLower();
            if (hasPluralsight == "y" || hasPluralsight =="yes")
            {
                newDev.HasPluralsight = true;
            }
            else
            {
                newDev.HasPluralsight = false;
            }


            Console.WriteLine("Select the developer's team assignment number.\n" +
                "1. Front End\n" +
                "2. Back End\n" +
                "3. Testing");

            string teamChoice = Console.ReadLine();
            bool isCorrect = false;
            while (isCorrect == false)
            {
                switch (teamChoice.ToLower())
                {
                    case "1":
                    case "one":
                        newDev.TeamAssignment = (TeamAssignment)1;
                        isCorrect = true;
                        break;

                    case "2":
                    case "two":
                        newDev.TeamAssignment = (TeamAssignment)2;
                        isCorrect = true;
                        break;

                    case "3":
                    case "three":
                        newDev.TeamAssignment = (TeamAssignment)3;
                        isCorrect = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        teamChoice = Console.ReadLine();
                        break;
                }
            }

            bool wasAddedCorrectly = _repo.AddDev(newDev);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The developer has been added.");
            }
            else
            {
                Console.WriteLine("Could not add the developer.");
            }
            //Console.WriteLine(newDev.TeamAssignment); check to see if assignment was added
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> allDevelopers = _repo.GetDevelopers();

            foreach (Developer developer in allDevelopers)
            {
                Console.WriteLine($"ID: {developer.DevID}\n" +
                    $"Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Has Pluralsight? {developer.HasPluralsight.ToString()}\n" + //try to make yes/no?
                    $"Team: {developer.TeamAssignment}");
            }
        }

        private void ViewDevelopersByTeams()
        {
            Console.Clear();
            Console.WriteLine("Select the number for the team you would like to see.\n" +
                 "1. Front End\n" +
                 "2. Back End\n" +
                 "3. Testing");

            List<Developer> devTeams = new List<Developer>();
            devTeams = _repo.GetDeveloperByTeam((TeamAssignment)Convert.ToInt32(Console.ReadLine()));
            if(devTeams != null)
            {
                foreach (Developer developer in devTeams)
                {
                    Console.WriteLine($"Name: {developer.FirstName} {developer.LastName}");
                }
            }
            else
            {
                Console.WriteLine("no devs on team");
            }
        }
    }
}
