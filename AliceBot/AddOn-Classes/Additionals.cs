using System;

namespace AliceBot
{
class Additionals {
        string codeblock = "```";
        string newline = "\n";
        
        public string DetermineTorF(string input) {
            try {
                input = input.Replace("^", "And").Replace("v", "Or").Replace("~", "Not");
                input = input.ToLower().Replace("||", "Or").Replace("&&", "And").Replace("!", "Not").Replace('t','T').Replace('f','F');

                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("", typeof(Boolean));
                table.Columns[0].Expression = input;

                System.Data.DataRow r = table.NewRow();
                table.Rows.Add(r);
                Boolean result = (Boolean)r[0];

                return result.ToString();
            }
            catch (Exception){
                return "error";
            }
        }
        
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

       public string HelpList() {
            string linkyBotInv = @"https://discordapp.com/oauth2/authorize?client_id=284975424105349120&scope=bot&permissions=1341643841";
            string linkyServer = @"https://discord.gg/cRjURSG";
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
                + "OrderBig - Rearrange a list of numbers from biggest to smallest." + newline
                + newline
                + "OrderSmall - Rearrange a list of numbers from smallest to biggest." + newline
                + newline
                + "GetMedian - Get the median value from a list of numbers." + newline
                + newline
                + "Pythagoras - Readup on Pythagoras' Theorem." + newline
                + newline
                + "Compare - Compares between 2 equations that returns a numerical value." + newline
                + newline
                + "Heron - Find the area of a triangle with length of 3 sides provided." + newline
                + newline
                + "TorF - evaluate if the statement is true or false." + newline
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
                + newline
                + "ToMorse - Convert a text message to Morse Code." + newline
                + newline
                + "caesarDecrypt - Decrypt a message using Caesar Cipher." + newline
                + newline
                + "caesarEncrypt - Encrypt a message using Caesar Cipher." + newline
                + newline
                + "WDlength - Returns the word count." + newline
                + codeblock
                + "You can invite me to your server(s) here : " + linkyBotInv + newline
                + "You can join my default server here : " + linkyServer + newline
                +"You can help to contribute my development here : " + DevHelp;

            return Helpppp;
        }

    }

}
