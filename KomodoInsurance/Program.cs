using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class Program
    {
        public static Team[] teams = new Team[0];

        static void Main(string[] args)
        {
            TeamRepository comLine = new TeamRepository();
            Console.WriteLine("Welcome to the Komodo Insurance Development Team Manager!");
            bool done = false;
            while (!done)
            {
                string command = "";
                command = Console.ReadLine();
                done = comLine.Commands(command);
            }
        }
    }
}
        /*static bool Commands (string command)
        {
            Program x = new Program();
            bool done = false;
            if (command == "exit" || command == "Exit")
            {
                done = true;
            }
            else if (command == "Add" || command == "add")
            {
                Console.WriteLine("Write the name of the team:");
                string noun = Console.ReadLine();
                Console.WriteLine("Type the id of the team");
                int ident = x.GetInt();
                Team create = new Team(new Developer[0], noun, ident);
                x.AddTeam(create);
                Console.WriteLine(noun + " has been successfully created!");
            }
            else if (command == "List" || command == "list")
            {
                Console.WriteLine();
                for (int i = 0; i < teams.Length; i++)
                {
                    Console.WriteLine(" - " + teams[i].name + ", ID: " + teams[i].id + ", " + teams[i].MemberCount() + " members");
                }

            }
            else if (command == "Team" || command == "team")
            {
                Console.WriteLine("Type the id of the team you want to manage");
                int id = x.GetInt();
                int e = x.GetTeamByID(id);
                Console.WriteLine("You are editing " + teams[e].name +".");
                bool check = false;
                while (!check)
                {
                    Console.WriteLine("Type 'Add' to add a new user, Type 'Assign' to add an existng user to the class, Type 'Remove' to remove a user, Type 'List' to list all members, Type 'Pluralsight' to list the pluralsight status of the members, or type 'Exit' to return.");
                    string commando = Console.ReadLine();
                    check = teams[e].Commands(commando);
                }
            }
            else if (command == "Help" || command == "help")
            {
                Console.WriteLine("Type 'Add' to create a team, Type 'List' to see all existing teams, Type 'Team' to manage teams, Type 'Help' for assistance, or Type 'Exit' to quit");
            }
            else
            {
                Console.WriteLine("That command was invalid");
            }
            return done;
        }
        public void AddTeam(Team bros)
        {
            int counter = TeamCount() + 1;
            Team[] tempCounter = new Team[10];
            tempCounter = teams;
            Array.Resize<Team>(ref tempCounter, counter);
            teams = tempCounter;
            teams[counter - 1] = bros;
        }
        public void RemoveTeam(int id)
        {
            string nombre = "";
            bool initRemov = false;
            int i = 0;
            while (i < staff.Length && !initRemov)
            {
                if (staff[i].id == id)
                {
                    initRemov = true;
                    nombre = staff[i].fullName;
                }
                else
                {
                    i++;
                }
            }
            if (initRemov)
            {
                Developer[] tempCounter = new Developer[10];
                tempCounter = staff;
                for (int j = i; j < staff.Length; j++)
                {
                    if (j < staff.Length - 1)
                    {
                        tempCounter[j] = staff[j + 1];
                    }
                    else
                    {
                        Array.Resize<Developer>(ref tempCounter, staff.Length - 1);
                        staff = tempCounter;
                    }
                }
                Console.WriteLine(nombre + " was succesfully removed.");
            }
            else
            {
                Console.WriteLine("That id was invalid.");
            }
        }
        public void ListTeamss()
        {
            for (int i = 0; i < staff.Length; i++)
            {
                Console.WriteLine(staff[i].fullName + " " + staff[i].id);
            }
        }
        public int GetTeamByID (int id)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetInt ()
        {
            string input = Console.ReadLine();
            int id = Convert.ToInt32(input);
            return id;
        }
        public int TeamCount()
        {
            int count = teams.Length;
            return count;
        }

            /*static void Main(string[] args)
            {
                Team group = new Team(new Developer[] { new Developer("Eric", "Cartman", 32, true), new Developer("Kyle", "Broflovski", 45, false), new Developer("Kenny", "McCormic", 12, true) }, "The Dudes", 420);
                
                int counter = group.MemberCount();
                Console.WriteLine("Your team has " + counter + " members!");
                group.AddMember(new Developer("Stan", "Marsh", 9, false));
                counter = group.MemberCount();
                Console.WriteLine("Now your team has " + counter + " members!");
                group.ListPluralsight(false);
                group.ListPluralsight(true);
                group.ListMembers();
                group.RemoveMember(12);
                group.ListMembers();

                Console.ReadLine();
            }*/


/*Our managers need to be able to add and remove members to/from a team by their unique 
identifier. They should be able to see a list of existing developers to choose from and 
add to existing teams. Odds are, the manager will create a team, and then add Developers 
individually from the Developer Directory to that team.*/

///////////////////////////////////////////////////////////////////////////////////////////

/*Your client Komodo Insurance has a number of software development teams and needs you to 
write a Console App to help their Product Managers manage them all.


You will need to create at least four different classes:
- Two POCOS: Developer, DevTeam
- Two Repositories: DeveloperRepo, DevTeamRepo

You will need to give the POCOs properties and and Repos need CRUD methods as appropriate.
You will then create a User Interface (Console Application) to build the functionality 
Komodo Insurance requires utilizing these classes. We have provided you with a few 
fields in the appropriate classes to help you in writing the CRUD Methods for the 
Developer and DevTeam POCOs.

You need to adhere to the guidelines from Komodo Insurance while writing their application 
to meet their needs in managing the DevTeams and Developers. Clients will typically not 
give you all the info you need, so you may need to use your brain and peers to fill in the 
blanks!

Info from Komodo Insurance:
- Developers have names and ID numbers; we need to be able to identify one developer without 
mistaking them for another. We also need to know whether or not they have access to the 
online learning tool: Pluralsight.

- Teams need to contain their Team members (Developers) and their Team Name, and Team ID.

- Our managers need to be able to add and remove members to/from a team by their unique 
identifier. 
- They should be able to see a list of existing developers to choose from and 
add to existing teams. Odds are, the manager will create a team, and then add Developers 
individually from the Developer Directory to that team.

- Challenge: Our HR Department uses the software monthly to get a list of all our Developers 
that need a Pluralsight license.
*/