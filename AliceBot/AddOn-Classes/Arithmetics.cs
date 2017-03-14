using System;

namespace AliceBot
{
    class Arithmetics
    {
        public char[] Allchars = {
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

        public char[] NonNumbericalchars = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ','
        };

        public char[] ForRearrangeUse = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ' '
        };
        
        public class MathFunctions
        {
            public double Pythagoras(double a, double b) {
                return Math.Sqrt( (Math.Pow(a, 2) + Math.Pow(b, 2)));
            }
            
            public long gcd(long a, long b) {
                long c;
                while (a != 0)
                {
                    c = a;
                    a = b % a;
                    b = c;
                }
                return b;
            }

            public long Phi(long n) {
                long ret = 0;
                for (long i = n - 1; i > 0; i--)
                {
                    if (gcd(n, i) == 1)
                        ret++;
                }
                return ret;
            }
        }

        public double QuadraticP(double[] Input) {
            double a = 0, b = 0, c= 0;
            for (int i = 0; i != 4; i++) {
                switch (i) {
                    case 0:
                        a = Input[i];
                        break;
                    case 1:
                        b = Input[i];
                        break;
                    case 2:
                        c = Input[i];
                        break;
                }

            }
            double x = ( (-b) + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c) ) )/(2*a);
            return x;
        }

        public double QuadraticN(double[] Input) {
            double a = 0, b = 0, c = 0;
            for (int i = 0; i != 4; i++)
            {
                switch (i)
                {
                    case 0:
                        a = Input[i];
                        break;
                    case 1:
                        b = Input[i];
                        break;
                    case 2:
                        c = Input[i];
                        break;
                }
            }
                double x = ((-b) - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
            return x;
        }

        public int IntAngle(int n) {
            int SumOfIntAngle = (n - 2) * 180;
            return SumOfIntAngle;
        }
        
        public bool PrimeCheck(long Number) {
            if (Number < 0 || Number == 0 || Number == 1)
            {
                return false;
            }
            else if (Number == 2)
            {
                return true;
            }
            for (long i = 2; i < Math.Sqrt(Number); i += 1) { 
                if (Number % i == 0) { return false; }
            }
            return true;
        }
        
        public string ArrangeToSmallest(string List) {
            string result =
            String.Join(", ",
             List
             .Split(',')
             .Select(s => Int64.Parse(s))
             .OrderBy(n => n)
             .Select(n => n.ToString())
             .ToArray()
             );

            return result;
        }

        public string ArrangeToLargest(string List) {
            string result =
            String.Join(", ",
             List
             .Split(',')
             .Select(s => Int64.Parse(s))
             .OrderBy(n => n)
             .Select(n => n.ToString())
             .ToArray()
             .Reverse()
             );
            return result;
        }
        
        public double FindMedian(double[] Input) {
            Array.Sort(Input);
            int Lengthy = Input.Length;
            double Output = 0;
            bool OddOrEven;
            if (Input.Length % 2 == 0) { OddOrEven = true; /*even*/ }
            else { OddOrEven = false; /*odd*/ }

            if (OddOrEven == true)
            {
                Output += (Input[(Input.Length - 1) / 2] + Input[((Input.Length -1) / 2 )+1])/2;
            }
            else if (OddOrEven == false) {
                Output += Input[((Input.Length - 1) / 2) ];
            }
            return Output;
        }
        
        public byte Compare(string First, string Second) {
            try
            {
                double A = Convert.ToDouble(Calculator(First));
                double B = Convert.ToDouble(Calculator(Second));
                if (A == B)
                {
                    return 0;
                }
                else if (A > B)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception) {
                return 3;
            }

        }

        private static double Calculator(string Input) {
            Input = Input.Replace("x", "*");
            Input = Input.Replace("X", "*");
            Input = Input.Replace("÷", "/");
            Input = Input.ToUpper().Replace("MOD", "%");
            Input = Input.ToUpper().Replace("PI", "3.14159265359");
                string value = new DataTable().Compute(Input, null).ToString();
                if (value == "NaN")
                {
                    return Double.MaxValue;
                }
                else
                {
                    return Convert.ToDouble(value);
                }
        }

    }
}
