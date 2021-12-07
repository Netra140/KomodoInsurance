using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class Developer
    {
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }
        public bool psAccess { get; set; }
        public Developer (string first, string last, int ident, bool ps)
        {
            firstName = first;
            lastName = last;
            id = ident;
            psAccess = ps;
            fullName = FullName (firstName, lastName);
            return;
        }
        public string FullName (string one, string two)
        {
            string full = one + " " + two;
            return full;
        }
    }
}

/*Developers have names and ID numbers; we need to be able to identify one developer without 
mistaking them for another. We also need to know whether or not they have access to the 
online learning tool: Pluralsight.*/