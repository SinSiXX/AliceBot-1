using System;

namespace AliceBot
{
class Additionals {

        string codeblock = "```";
        string newline = "\n";

        public string HelpList() {
            string linkyBotInv = @"https://discordapp.com/oauth2/authorize?client_id=284975424105349120&scope=bot&permissions=1341643841";
            string linkyServer = @"https://discord.gg/94RvCgd";
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
                + "You can join my default server here : " + linkyServer;

            return Helpppp;
        }

    }

}
