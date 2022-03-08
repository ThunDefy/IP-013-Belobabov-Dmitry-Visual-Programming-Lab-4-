using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class RomanNumberExtend : RomanNumber
    {
        public RomanNumberExtend(string snum) : base(1)
        {
            ushort answ = 0;
            for (int i = 0; i < snum.Length; i++)
            {
                char ch = snum[i];
                if (ch == 'M')
                    answ += 1000;
                else if (ch == 'D')
                    answ += 500;
                else if (ch == 'C')
                    answ += 100;
                else if (ch == 'L')
                    answ += 50;
                else if (ch == 'X')
                    answ += 10;
                else if (ch == 'V')
                    answ += 5;
                else if (ch == 'I')
                    answ += 1;
            }
            num = answ;
        }
    }
}
