using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class DeveloperRepository
    {
        public Team w = new Team(new Developer[0], " ", -1);
        Developer[] staff { get; set; }
        public bool Commands(string command, Team temp)
        {
            w = temp;
            staff = w.staff;
            if (command == "Add" || command == "add")
            {
                Console.WriteLine("Please provide the developer's first name: ");
                string first = Console.ReadLine();
                Console.WriteLine("Please provide the developer's last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("Please provide the developer's unique id: ");
                string ident = Console.ReadLine();
                int id = int.Parse(ident);
                //Check if id is unique
                Console.WriteLine("Is the user registered with pluralsight? Type 'Yes' or 'No'");
                string booler = Console.ReadLine();
                if (booler == "Yes" || booler == "yes")
                {
                    Developer child = new Developer(first, last, id, true);
                    AddMember(child);
                }
                else if (booler == "No" || booler == "no")
                {
                    Developer child = new Developer(first, last, id, false);
                    AddMember(child);
                }
                else
                {
                    Console.WriteLine("Invalid input, registration canceled");
                }
            }
            else if (command == "Remove" || command == "remove")
            {
                Console.WriteLine("Please provide the id of the user you wish to remove");
                string inp = Console.ReadLine();
                int id = int.Parse(inp);
                int dude = GetByID(id);
                Console.WriteLine("Are you sure you want to get rid of " + staff[dude].fullName + "? Type 'Confirm' if so.");
                string confirm = Console.ReadLine();
                if (confirm == "Confirm" || confirm == "confirm")
                {
                    RemoveMember(id);
                }
                else
                {
                    Console.WriteLine("Termination Aborted");
                }
            }
            else if (command == "Assign" || command == "assign")
            {
                Console.WriteLine("Please insert the id of an existing user: ");
                string ID = Console.ReadLine();
                int id = int.Parse(ID);
                assignMember(id);
            }
            else if (command == "List" || command == "list")
            {
                ListMembers();
            }
            else if (command == "Pluralsight" || command == "pluralsight")
            {
                Console.WriteLine("Type 'Has' to see which members are registered, or type 'Hasn't' to see which members need to be registered.");
                string psight = Console.ReadLine();
                if (psight == "Has" || psight == "has")
                {
                    ListPluralsight(true);
                }
                else if (psight == "Hasn't" || psight == "hasn't" || psight == "Hasnt" || psight == "hasnt")
                {
                    ListPluralsight(false);
                }
            }
            else if (command == "Exit" || command == "exit")
            {
                return true;
            }
            else { Console.WriteLine("Your command was invalid"); }

            w.staff = staff;
            return false;
        }
        public void assignMember(int id)
        {
            Developer[] DevCache = w.GetDevCache();
            for (int i = 0; i < DevCache.Length; i++)
            {
                if (DevCache[i].id == id)
                {
                    int counter = MemberCount() + 1;
                    Developer[] tempCounter = new Developer[10];
                    tempCounter = staff;
                    Array.Resize<Developer>(ref tempCounter, counter);
                    staff = tempCounter;
                    staff[counter - 1] = DevCache[i];
                    return;
                }
            }
            Console.WriteLine("No such user exists, please try again.");
        }
        public void AddMember(Developer guy)
        {
            Developer[] DevCache = w.GetDevCache();
            for (int i = 0; i < DevCache.Length; i++)
            {
                if (guy.id == DevCache[i].id)
                {
                    Console.WriteLine("ID is already taken by " + DevCache[i].fullName);
                    return;
                }
            }

            int counter = MemberCount() + 1;
            Developer[] tempCounter = new Developer[10];
            /*Developer[] timpCounter = new Developer[10];

            timpCounter = DevCache;*/
            Array.Resize<Developer>(ref DevCache, DevCache.Length + 1);
            DevCache[DevCache.Length - 1] = guy;
            w.SetDevCache(DevCache);

            tempCounter = staff;
            Array.Resize<Developer>(ref tempCounter, counter);
            staff = tempCounter;
            staff[counter - 1] = guy;
        }
        public void RemoveMember(int id)
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
        public void ListMembers()
        {
            for (int i = 0; i < staff.Length; i++)
            {
                Console.WriteLine(staff[i].fullName + " " + staff[i].id);
            }
        }

        //Challenge: Our HR Department uses the software monthly to get a list of all our Developers 
        //that need a Pluralsight license.
        public Developer[] Pluralsight(bool has)
        {
            int size = MemberCount();
            Developer[] psAccessed = new Developer[0];
            int i = 0;
            while (i < size)
            {
                if (staff[i].psAccess == has)
                {
                    Array.Resize<Developer>(ref psAccessed, psAccessed.Length + 1);
                    psAccessed[psAccessed.Length - 1] = staff[i];
                }
                i++;
            }
            return psAccessed;
        }
        public void ListPluralsight(bool has)
        {
            Developer[] psSpecification = Pluralsight(has);
            string list = "";
            for (int i = 0; i < psSpecification.Length; i++)
            {
                if (i == psSpecification.Length - 1)
                {
                    list += "and ";
                }
                list += psSpecification[i].fullName;
                list += " ";
                list += psSpecification[i].id;
                if (i < psSpecification.Length - 1)
                {
                    list += ", ";
                }
            }
            if (has)
            {
                if (psSpecification.Length == 1)
                {
                    list += " has Pluralsight.";
                }
                else
                {
                    list += " have Pluralsight.";
                }

            }
            else
            {
                if (psSpecification.Length == 1)
                {
                    list += " doesn't have Pluralsight yet.";
                }
                else
                {
                    list += " don't have Pluralsight yet.";
                }
            }
            Console.WriteLine(list);
        }
        public int GetByID(int id)
        {
            for (int i = 0; i < staff.Length; i++)
            {
                if (staff[i].id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public int MemberCount()
        {
            int count = staff.Length;
            return count;
        }
    }
    //Teams need to contain their Team members(Developers) 
    //and their Team Name, and Team ID.
}
