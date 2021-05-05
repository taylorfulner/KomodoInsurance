using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private List<Developer> _devDirectory = new List<Developer>();

        //CRUD - Create
        public bool AddDev(Developer newDev)
        {
            int startingCount = _devDirectory.Count;

            _devDirectory.Add(newDev);

            bool wasAdded = (_devDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //CRUD - Read (view)
        //view all developers
        public List<Developer> GetDevelopers()
        {
            return _devDirectory;
        }

        //search developer by team assignment
        public List<Developer> GetDeveloperByTeam(TeamAssignment teamAssignment)
        {
            List<Developer> byTeam = new List<Developer>();

            foreach (Developer devMember in _devDirectory)
            {
                if (teamAssignment == devMember.TeamAssignment)
                {
                    byTeam.Add(devMember);
                }
            }
            return byTeam;
        }
    }
}
