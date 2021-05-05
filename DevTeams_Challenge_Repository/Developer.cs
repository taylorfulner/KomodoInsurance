﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd = 1, BackEnd, Testing}
    public class Developer
    {
        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
            //ID
            //FirstName
            //LastName
            //a bool that shows whether they have access to the online learning tool Pluralsight.
            //TeamAssignment - use the enum declared above this class
        public int DevID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPluralsight { get; set; }
        public TeamAssignment TeamAssignment { get; set; }

        public Developer() { }

        public Developer(int devID, string firstName, string lastName, bool hasPluralsight, TeamAssignment teamAssignment) 
        {
            DevID = devID;
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
            TeamAssignment = teamAssignment;
        }

    }
}
