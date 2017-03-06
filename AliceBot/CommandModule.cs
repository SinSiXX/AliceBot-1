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
        Arithmetics.MathFunctions MFuncty = new Arithmetics.MathFunctions();

        private static string GetUptime() => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();

        [Command("Help", RunMode = RunMode.Async)]
        public async Task Help()
        {
            var user = Context.User;
            var x = await user.CreateDMChannelAsync();
            await x.SendMessageAsync(AddCmd.HelpList());
        }

        [Command("calculate", RunMode = RunMode.Async)]
        public async Task Calculate([Remainder]string equation)
        { //Needs improvement
            usage = "Usage : `|calculate <equation>` , where `equation` must not contain any functions.";

            equation = equation.Replace("x", "*");
            equation = equation.Replace("X", "*");
            equation = equation.Replace("÷", "/");
            equation = equation.ToUpper().Replace("MOD", "%");
            equation = equation.ToUpper().Replace("PI", "3.14159265359");
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
