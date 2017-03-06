using System;

namespace AliceBot
{
class Additionals {

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
                    Console.WriteLine(Output[i]);
                }
                else if (i == 1)
                {
                    int x = input.IndexOf(',');
                    int y = input.LastIndexOf(',');
                    Output[i] = Convert.ToDouble(input.Substring(x, y-x).Replace(",", ""));
                    Console.WriteLine(Output[i]);
                    input = input.Remove(0, y);
                }
                else if (i == 2) {
                    Output[i] = Convert.ToDouble(input.Replace(",", ""));
                    Console.WriteLine(Output[i]);
                }
            }
            return Output;
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
                + "quadratic - Lookup on quadratic formulas. [May be buggy!]" + newline
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
                + "RoleIDs - Returns a list of roles and their ID on the server."
                + newline
                + codeblock
                + "You can invite me to your server(s) here : " + linkyBotInv + newline
                + "You can join my default server here : " + linkyServer + newline
                +"You can help to contribute my development here : " + DevHelp;

            return Helpppp;
        }

    }

}
