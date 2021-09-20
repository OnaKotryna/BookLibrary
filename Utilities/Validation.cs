using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Utilities
{
    public static class Validation
    {
        public static bool CheckInt(int action)
        {
            return action.GetType() == typeof(int);
        }
    }
}
