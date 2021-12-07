using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class TeamRepository
    {
        static Team[] teams = new Team[0];
        DeveloperRepository dRepo = new DeveloperRepository();
        public bool Commands(string command)
        {
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
                int ident = GetInt();
                Team create = new Team(new Developer[0], noun, ident);
                AddTeam(create);
                Console.WriteLine(noun + " has been successfully created!");
            }
            else if (command == "Remove" || command == "remove")
            {
                Console.WriteLine("Please provide the id of the team you wish to remove");
                string inp = Console.ReadLine();
                int id = int.Parse(inp);
                int dude = GetByID(id);
                Console.WriteLine("Are you sure you want to get rid of " + teams[dude].name + "? Type 'Confirm' if so.");
                string confirm = Console.ReadLine();
                if (confirm == "Confirm" || confirm == "confirm")
                {
                    RemoveTeam(id);
                }
                else
                {
                    Console.WriteLine("Termination Aborted");
                }
            }
            else if (command == "List" || command == "list")
            {
                ListTeams();

            }
            else if (command == "Team" || command == "team")
            {
                Console.WriteLine("Type the id of the team you want to manage");
                int id = GetInt();
                int e = GetTeamByID(id);
                Console.WriteLine("You are editing " + teams[e].name + ".");
                bool check = false;
                while (!check)
                {
                    Console.WriteLine("Type 'Add' to add a new user, Type 'Assign' to add an existng user to the class, Type 'Remove' to remove a user, Type 'List' to list all members, Type 'Pluralsight' to list the pluralsight status of the members, or type 'Exit' to return.");
                    string commando = Console.ReadLine();
                    check = dRepo.Commands(commando,teams[e]);
                    teams[e]= dRepo.w;
                }
            }
            else if (command == "Developers" || command == "developers")
            {
                ListDevCache();
            }
            else if (command == "Help" || command == "help")
            {
                Console.WriteLine("Type 'Add' to create a team, Type 'Remove' to delete a team, Type 'List' to see all existing teams, Type 'Team' to manage teams, Type 'Help' for assistance, type 'Developers' to get a list of registered developers, or Type 'Exit' to quit");
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
            while (i < teams.Length && !initRemov)
            {
                if (teams[i].id == id)
                {
                    initRemov = true;
                    nombre = teams[i].name;
                }
                else
                {
                    i++;
                }
            }
            if (initRemov)
            {
                Team[] tempCounter = new Team[10];
                tempCounter = teams;
                for (int j = i; j < teams.Length; j++)
                {
                    if (j < teams.Length - 1)
                    {
                        tempCounter[j] = teams[j + 1];
                    }
                    else
                    {
                        Array.Resize<Team>(ref tempCounter, teams.Length - 1);
                        teams = tempCounter;
                    }
                }
                Console.WriteLine(nombre + " was succesfully removed.");
            }
            else
            {
                Console.WriteLine("That id was invalid.");
            }
        }
        public void ListTeams()
        {
            Console.WriteLine();
            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine(" - " + teams[i].name + ", ID: " + teams[i].id + ", " + teams[i].MemberCount() + " members");
            }
        }
        void ListDevCache ()
        {
            Team temp = new Team(new Developer[0], " ", -1);
            Developer[] guys = temp.GetDevCache();
            for (int i = 0; i < guys.Length; i++)
            {
                Console.WriteLine(guys[i].fullName + " " + guys[i].id);
            }
        }
        public int GetTeamByID(int id)
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
        public int GetByID(int id)
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
        public int GetInt()
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

    }
}