using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterChairina.Controller
{
    public class NameCompare : IComparer<string>
    {
        public int Compare(string FirstName, string LastName)
        {
            if (FirstName == null && LastName == null) return 0;
            if (FirstName == null || LastName == null) return -1;

            var x = FirstName.Split();
            var y = LastName.Split();

            if (x.Length > 1 && y.Length > 1)
            {
                if (x[0] != y[0]) return x[0].CompareTo(y[0]);

                return x[1].CompareTo(y[1]);
            }

            return FirstName.CompareTo(LastName);
            //throw new NotImplementedException();
        }
    }
}
