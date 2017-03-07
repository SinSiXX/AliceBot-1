using System;

namespace AliceBot
{
class Additionals {
        
        public char[] NonBinaryChar = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '2', '3', '4', '5',
            '6', '7', '8', '9', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ','
        };

        string codeblock = "```";
        string newline = "\n";
        
        public double[] Return3Number(string input) {
            double[] Output = new double[3];
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    int x = input.IndexOf(',');
                    Output[i] = Convert.ToDouble(input.Substring(0, x).Replace(",",""));
                }
                else if (i == 1)
                {
                    int x = input.IndexOf(',');
                    int y = input.LastIndexOf(',');
                    Output[i] = Convert.ToDouble(input.Substring(x, y-x).Replace(",", ""));
                    input = input.Remove(0, y);
                }
                else if (i == 2) {
                    Output[i] = Convert.ToDouble(input.Replace(",", ""));
                }
            }
            return Output;
        }
        
        public string ToBinary(string Input){
            ASCIIEncoding encode = new ASCIIEncoding();
            string output = "";
            foreach (char c in Input) {
               output += Convert.ToString(c, 2).PadLeft(8, '0') + " ";
            }
            return output;
        }

        public string FromBinary(string binary){
            string output = "";
            binary = binary.Replace(" ", "");
            for (int i = 0; i < binary.Length; i += 8)
            {
                string C = binary.Substring(i, 8);
                output += (char)Convert.ToByte(C, 2);
            }
            return output;

        }

        public string HelpList() {
            string linkyBotInv = @"https://discordapp.com/oauth2/authorize?client_id=284975424105349120&scope=bot&permissions=1341643841";
            string linkyServer = @"https://discord.gg/94RvCgd";
            string DevHelp = @"https://github.com/House-of-Alice-Margatroid/AliceBot";
            string Helpppp = codeblock
                + "Markdown" + newline
                + "This bot is mainly for Arithmetic/Algorithm uses." + newline
                + "Prefix : |" + newline
                + newline
                + "Arithmetic/Algorithm Commands"
                + newline
                + "==========================" + newline
                + "entropy - Used to calculate password strength" + newline
                + newline
                + "calculate - Calcualator" + newline
                + newline
                + "GDC - Used to find the Greatest Common Divisor between 2 numbers." + newline
                + newline
                + "Phi - Used to find the Phi of any number." + newline
                + newline
                + "IntPolygon - Find the sum of interior angles of a polygon with n-sides." + newline
                + newline
                + "quadratic - Lookup on quadratic formulas." + newline
                + newline
                + "CheckPrime - Check if the number is prime or not." + newline
                + newline
                + "OrderBig - Rearrange a list of numbers from biggest to smallest" + newline
                + newline
                + "OrderSmall - Rearrange a list of numbers from smallest to biggest" + newline
                + newline
                + "Fun/Game Commands"
                + newline
                + "==========================" + newline
                + "Roll" + newline
                + newline
                + "Other Commands"
                + newline
                + "==========================" + newline
                + "RoleIDs - Returns a list of roles and their ID on the server." + newline
                + newline
                + "ToBinary - Convert a text message to binary." + newline
                + newline
                + "FromBinary - Converts a binary message to text." + newline
                + codeblock
                + "You can invite me to your server(s) here : " + linkyBotInv + newline
                + "You can join my default server here : " + linkyServer + newline
                +"You can help to contribute my development here : " + DevHelp;

            return Helpppp;
        }

    }

}
