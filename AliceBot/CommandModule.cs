using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Data;
using System.IO;

namespace AliceBot
{
    public class CommandModules : ModuleBase
    {
        string usage;
        string codeblock = "```";
        string newline = "\n";

        Ping pingSender = new Ping();
        Random randy = new Random();
        Arithmetics Arith = new Arithmetics();
        Additionals AddCmd = new Additionals();
        Converters CVert = new Converters();
        Arithmetics.MathFunctions MFuncty = new Arithmetics.MathFunctions();

        private static string GetUptime() => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();

        [Command("Help", RunMode = RunMode.Async)]
        public async Task Help()
        {
        //Sends the list of commands to the user's inbox
            var x = await Context.User.CreateDMChannelAsync();
            await x.SendMessageAsync(AddCmd.HelpList());
        }

        [Command("calculate", RunMode = RunMode.Async)]
        public async Task Calculate([Remainder]string equation)
        { //Needs improvement
            usage = "Usage : `|-calculate <equation>` , where `equation` must not contain any functions.";
            //Replaces all the possible math symbols that may appear
            //Invalid for the computer to compute
            equation = equation.ToUpper()
            .Replace("x", "*")
            .Replace("X", "*")
            .Replace("÷", "/")
            .Replace("MOD", "%")
            .Replace("PI", "3.14159265359")
            .Replace("E", "2.718281828459045");
            try
            {
                string value = new DataTable().Compute(equation, null).ToString();
                if (value == "NaN")
                {
                    await Context.Channel.SendMessageAsync("Infinity or undefined");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(value);
                }
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("?");
            }
        }
    }
}
