using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    public class Owner : IOwner
    {
        static int objNumber = 0;
        static List<Owner> objList = new List<Owner>();
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Owner(string fn, string ln)
        {
            ID = ++objNumber;
            FirstName = fn;
            LastName = ln;

            objList.Add(this);
        }

        public static List<Owner> GetExistingOwners() => Owner.objList;
        public override string ToString() => $"{ID} - {FirstName} {LastName}";
    }
}
