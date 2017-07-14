using System;

namespace AliceBot
{
    class Arithmetics
    {
        //Stores ASCII for all the common characters shown on keyboard.
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

        //Does the same as above, but does not store numerical values.
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

        //Used in one of the functions, does not contain some symbols
        //And have other symbols instead.
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
            private Random randy = new Random();

            //Based on Heron's theorem
            public double Heron(double a, double b, double c) {
                if (0 > a || 0 > b || 0 > c) { 
                    return 0 / randy.Next(0,0);
                }
                double S = (a + b + c) / 2;
                return Math.Sqrt(S * (S-a) * (S - b) * (S - c));
            }
            
            //Uses Pythagoras theorem
            public double Pythagoras(double a, double b) {
                return Math.Sqrt( (Math.Pow(a, 2) + Math.Pow(b, 2)));
            }
            
            //Finds the greatest common divisor between two numbers
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

            //Finds the Phi of a number
            public long Phi(long n) {
                long ret = 0;
                for (long i = n - 1; i > 0; --i)
                {
                    if (gcd(n, i) == 1)
                        ++ret;
                }
                return ret;
            }
        }

        //Solves Quadratic equation and gives only the positive result
        //If there is one
        public double QuadraticP(double[] Input) {
            double a = 0, b = 0, c= 0;
            for (int i = 0; i != 4; ++i) {
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

        //Solves Quadratic equation and gives only the negative result
        //If there is one.
        public double QuadraticN(double[] Input) {
            double a = 0, b = 0, c = 0;
            for (int i = 0; i != 4; ++i)
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

        //Finds the sum of angles in a shape given the number of sides.
        public int IntAngle(int n) {
            return (n - 2) * 180;
        }
        
        //Checks if number is prime
        //Only used for small numbers
        //Fermat theorem is used for larger values.
        public bool PrimeCheck(long Number) {
            if (Number < 0 || Number == 0 || Number == 1)
            {
                return false;
            }
            else if (Number == 2)
            {
                return true;
            }
            for (long i = 2; i < Math.Sqrt(Number); ++i) { 
                if (Number % i == 0) { return false; }
            }
            return true;
        }
        
        //Arrange a list of numbers from largest to smallest
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

        //Arrange a list of numbers from smallest to largest
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
        
        //Finds the median from a list of numbers
        public double FindMedian(double[] Input) {
            Array.Sort(Input);

            bool OddOrEven;
            //Check if the array length is even or odd
            //If even OddOrEven will become true.
            if (Input.Length % 2 == 0) { OddOrEven = true; }
            else { OddOrEven = false; }

            if (OddOrEven == true)
            {
                return (Input[(Input.Length - 1) / 2] + Input[((Input.Length -1) / 2 )+1])/2;
            }
            else if (OddOrEven == false) {
                return Input[((Input.Length - 1) / 2) ];
            }
            return 0;
        }
        
        //Compares between two values and compute which is larger or smaller
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

        //Its a calculator
        private static double Calculator(string Input) {
            //Replaces math symbols that the system cannot compute
            //Into computable symnbols
            Input =  Input.ToUpper()
                .Input.Replace("X", "*")
                .Input.Replace("÷", "/")
                .Replace("MOD", "%")
                .Replace("PI", "3.14159265359")
                .Replace("E", "2.718281828459045");
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
        
        //Ceaser Cipher to decrypt texts
        public string Decrypt(string cip, int offset)
        {
            char[] cipher = cip.ToCharArray();

            for (int i = 0; i < cipher.Length; ++i)
            {
                for (int j = 0; j < Allchars.Length; ++j)
                {
                    if (j >= offset && cipher[i] == Allchars[j])
                    {
                        cipher[i] = Allchars[j - offset];
                        break;
                    }
                    if (cipher[i] == Allchars[j] && j < offset)
                    {
                        cipher[i] = Allchars[(Allchars.Length - offset + 1) + j];
                        break;
                    }
                }
            }
            return new string(cipher);
        }

        //Ceaser Cipher to encrypt texts
        public string Encrypt(string text, int offset)
        {
            char[] plain = text.ToCharArray();

            for (int i = 0; i < plain.Length; ++i)
            {
                for (int j = 0; j < Allchars.Length; ++j)
                {
                    if (j <= Allchars.Length - offset)
                    {
                        if (plain[i] == Allchars[j])
                        {
                            plain[i] = Allchars[j + offset];
                            break;
                        }
                    }
                    else if (plain[i] == Allchars[j])
                    {
                        plain[i] = Allchars[j - (Allchars.Length - offset + 1)];
                    }
                }
            }
            return new string(plain);
        }

    }
}
