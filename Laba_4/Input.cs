using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    class Input
    {
        public static int ReadInt()
        {
            int r;
            bool negative = false;
            while (true)
            {
                r = Console.Read();
                if (r == '-' || r >= '0' && r <= '9')
                    break;
            }

            int p = 0;
            if (r == '-')
                negative = true;
            else
                p = r - '0';

            while (true)
            {
                r = Console.Read() - '0';
                if (r >= 0 && r <= 9)
                    p = p * 10 + r;
                else
                    return negative ? -p : p;
            }
        }

        public static int ReadInt(System.IO.StreamReader sr)
        {
            int r;
            bool negative = false;
            while (true)
            {
                r = sr.Read();
                if (r == '-' || r >= '0' && r <= '9')
                    break;
            }

            int p = 0;
            if (r == '-')
                negative = true;
            else
                p = r - '0';

            while (true)
            {
                r = sr.Read() - '0';
                if (r >= 0 && r <= 9)
                    p = p * 10 + r;
                else
                    return negative ? -p : p;
            }
        }
    }
}

