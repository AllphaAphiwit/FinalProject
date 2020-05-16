using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Globals
    {
        public static int Global_userid { get; private set; }

        public static void SetGlobal_userid(int UserId)
        {
            Global_userid = UserId;
        }
    }
}
