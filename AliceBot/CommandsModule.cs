using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.Net.NetworkInformation;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Addons.InteractiveCommands;

/*Setup stuffs are not included in this code to prevent long codes..*/

namespace AliceBot
{

//All the setup stuffs......

public class CommandsModule : InteractiveModuleBase //Discord.Net InteractiveCommands is being used too.
    {
        string usage;
        string codeblock = "```";
        string newline = "\n";

        public DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 1000,
            });

        Ping pingSender = new Ping();
        Random randy = new Random();
        Arithmetics Arith = new Arithmetics();
        Additionals AddCmd = new Additionals();
        Arithmetics.MathFunctions MFuncty = new Arithmetics.MathFunctions();

        private static string GetUptime() => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();

    //Not all commands are included to prevent code floods.
    
        [Command("Help", RunMode = RunMode.Async)]
        public async Task Help() {
            var user = Context.User;
            var x = await user.CreateDMChannelAsync();
            await x.SendMessageAsync(AddCmd.HelpList());
        }

        [Command("Input", RunMode = RunMode.Async)]
        public async Task Output(){
            if (Context.Message.Author.Id != 129213229221019648 /*Wen Qin's ID*/) { }
            else
            {
                var y = Context.Guild.DefaultChannelId;
                await Context.Channel.SendMessageAsync(codeblock
                    + "Uptime in DD:HH:mm:ss : " + GetUptime() + newline
                    + "Heap Memory used : " + GetHeapSize() 
                    + codeblock
                    );
            }
        }

        [Command("quadratic", RunMode = RunMode.Async)]
        public async Task quadratic() {
            double a = 0, b = 0, c = 0;
            usage = "Usage : `quadratic <a> <b> <c>` , where `a` , `b` and `c` are values.";

            A:
            await ReplyAsync("From the quadratic equation, input the value of `a`, where `a` is a number.");
            var response = await WaitForMessage(Context.User, Context.Channel);
            string stringy = response.Content;
            try { a = Convert.ToDouble(stringy); } catch (Exception) { goto A; }

            B:
            await ReplyAsync("From the quadratic equation, input the value of `b`, where `b` is a number.");
            response = await WaitForMessage(Context.User, Context.Channel);
            stringy = response.Content;
            try { b = Convert.ToDouble(stringy); } catch (Exception) { goto B; }

            C:
            await ReplyAsync("From the quadratic equation, input the value of `c`, where `c` is a number.");
            response = await WaitForMessage(Context.User, Context.Channel);
            stringy = response.Content;
            try { c = Convert.ToDouble(stringy); } catch (Exception) { goto C; }

            double FirstR = Arith.QuadraticN(a, b, c);
            double SecondR = Arith.QuadraticP(a, b, c);
            if (FirstR.ToString() == "NaN" || SecondR.ToString() == "NaN") {
                await Context.Channel.SendMessageAsync("x = infinity or undefined");
            }
            else if (FirstR == SecondR) { await Context.Channel.SendMessageAsync("x = " + FirstR); }
            else
            {
                await Context.Channel.SendMessageAsync("x = " + FirstR
                    + newline + "OR"
                    + newline + "x = " + SecondR
                    );
            }
        }

        [Command("entropy", RunMode = RunMode.Async)]
        public async Task EntropyCmd([Remainder]string password){
            EntropyCal cal = new EntropyCal();
            await Context.Channel.SendMessageAsync("Entropy Value : ~" + cal.EntropyValue(password) + newline
                + "Entropy Bits : ~" + cal.EntropyBits(password));
        }

        [Command("calculate", RunMode = RunMode.Async)]
        public async Task Calculate([Remainder]string equation){
            usage = "Usage : `|calculate <equation>` , where `equation` must not contain any functions.";

            equation = equation.Replace("x", "*");
            equation = equation.Replace("X", "*");
            equation = equation.Replace("÷", "/");
            equation = equation.ToUpper().Replace("MOD", "%");
            try
            {
                string value = new DataTable().Compute(equation, null).ToString();
                if (value == "NaN"){
                    await Context.Channel.SendMessageAsync("Infinity or undefined");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(value);
                }
            }
            catch (Exception){
                await Context.Channel.SendMessageAsync("?");
            }
        }

        [Command("GDC", RunMode = RunMode.Async)]
        public async Task GDC(double A, double B) {
            usage = "Usage : `|GDC <a> <b>` , where `a` and `b` should be whole numbers.";
            if (A.ToString().Contains(".") || B.ToString().Contains(".")){
                await Context.Channel.SendMessageAsync(usage);
            }else{
                try{
                    int result = MFuncty.gcd(Convert.ToInt32(A), Convert.ToInt32(B));
                    string output;
                    output = "Greatest Common Divisor of ";
                    output = output.Insert(output.Length, A + " and " + B + " is `" + result + "`");

                    await Context.Channel.SendMessageAsync(output);
                }catch (Exception){
                    await Context.Channel.SendMessageAsync(usage);
                }
            }

        }

        [Command("GuessNo", RunMode = RunMode.Async)]
        public async Task Guess(int n = -1) {
            usage = "usage : `|GuessNo <n>` , where n is a positive number below 1001";
            if (n < 0 || n > 1000)
            {
                await Context.Channel.SendMessageAsync(usage);
            }
            else { 
                var TheNumberToGuess = randy.Next(0, 1000);
                int tries = 0;
                int rip = n;
                IUserMessage response;
            LoopOne:
                await Context.Channel.SendMessageAsync("Input your next number. Make sure it is a positive number below 1001");
                response = await WaitForMessage(Context.User, Context.Channel);
                try { rip = Convert.ToInt16(response.ToString()); } catch { goto LoopOne; }
                if (TheNumberToGuess == rip)
                {
                    await Context.Channel.SendMessageAsync("You have guessed correctly the number in " + tries + " tries! The answer was " + TheNumberToGuess);
                }
                else if (TheNumberToGuess > rip)
                {
                    await Context.Channel.SendMessageAsync("Your choosen number is smaller than the answer. Your current No of tries : " + ++tries);
                    goto LoopOne;
                }
                else if (TheNumberToGuess < rip) {
                    await Context.Channel.SendMessageAsync("Your choosen number is bigger than the answer. Your current No of tries : " + ++tries);
                    goto LoopOne;
                }
            }

        }

                }
}
