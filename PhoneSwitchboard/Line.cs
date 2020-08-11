using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSwitchboard
{
    class Line
    {
        public int A;
        public int B;
        public int Number;
        public string Status;
        public int Time; // in seconds

        public Line()
        {
            A = -1;
            B = -1;
            Number = -1;
            Status = "Waiting";
            Time = 0;
        }
    }
}
