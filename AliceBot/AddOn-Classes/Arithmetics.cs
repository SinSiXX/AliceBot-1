using System;

namespace AliceBot
{
    class Arithmetics
    {
        public char[] chars = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ',', ' '
        };

        public class MathFunctions
        {
            public long gcd(long a, long b)
            {
                long c;
                while (a != 0)
                {
                    c = a;
                    a = b % a;
                    b = c;
                }
                return b;
            }

            public long Phi(long n)
            {
                long ret = 0;
                for (long i = n - 1; i > 0; i--)
                {
                    if (gcd(n, i) == 1)
                        ret++;
                }
                return ret;
            }
        }

        public double QuadraticP(double a, double b, double c) {
            double x = ( (-b) + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c) ) )/(2*a);
            return x;
        }

        public double QuadraticN(double a, double b, double c)
        {
            double x = ((-b) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            return x;
        }

        public int IntAngle(int n) {
            int SumOfIntAngle = (n - 2) * 180;
            return SumOfIntAngle;
        }

    }
}
