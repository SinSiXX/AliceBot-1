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

/*Scroll down to CommandsModule class to start helping with the commands.
The rest are mainly setup stuffs.*/

namespace AliceBot
{

class Program
    {
        public DiscordSocketClient client;

        string codeblock = "```";
        string newline = "\n";

        static void Main(string[] args) => new Program().Run().GetAwaiter().GetResult();

        public async Task Run() {
            Arithmetics Arith = new Arithmetics();
            Additionals AddCmd = new Additionals();

            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 1000,
            });

            string Mytoken = "TOKEN";
            await client.LoginAsync(TokenType.Bot, Mytoken);
        Retrying:
            try
            {
                await client.ConnectAsync();
            }catch (TimeoutException){
                goto Retrying;
            }

            await client.SetGameAsync("Multi-Threading");
            var guildcount = client.Guilds.Count;
            var map = new DependencyMap();
            ConfigureServices(map);
            await new CommandHandler().Install(map);

            //Delegates stuffs (user leaving, etc), no modification/help needed for now.

            await Task.Delay(-1);
    }
        public void ConfigureServices(IDependencyMap map){
            map.Add(client);
        }

        public class CommandHandler{
            private CommandService _commands;
            private DiscordSocketClient _client;
            private IDependencyMap _map;

            public async Task Install(IDependencyMap map){
                _commands = new CommandService();
                await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
                map.Add(_commands);
                _map = map;
                _client = map.Get<DiscordSocketClient>();
                _map.Add(new InteractiveService(_client));
                _client.MessageReceived += HandleCommand;
            }

            private async Task HandleCommand(SocketMessage messageParam){
                var message = messageParam as SocketUserMessage;
                if (message == null) return;

                int argPos = 0;
                if (!(message.HasMentionPrefix(_client.CurrentUser, ref argPos) || message.HasStringPrefix("|", ref argPos))) return;

                var context = new CommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _map);
            }
        }
    }

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

        [Command("RoleIDs", RunMode = RunMode.Async)]
        public async Task Idrole()
        {
            int NoOfRoles = Context.Guild.Roles.Count;
            var roles = Context.Guild.Roles;
            string wat = "```";
            try
            {
                for (int x = 1; x < NoOfRoles; x++)
                {
                    wat = wat.Insert(wat.Length, roles.ElementAt(x).Id.ToString());
                    wat = wat.Insert(wat.Length, " : " + roles.ElementAt(x).ToString() + newline);
                }
                wat = wat.Insert(wat.Length, codeblock);
                await Context.Channel.SendMessageAsync(wat);
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync(e.ToString());
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

        [Command("Phi", RunMode = RunMode.Async)]
        public async Task Phi([Remainder]string equation){
            usage = "Usage : `|Phi <equation>` , where `equation` must not contain any functions , and the result should be lower than 5000.";
            equation = equation.Replace("x", "*");
            equation = equation.Replace("X", "*");
            equation = equation.Replace("÷", "/");
            equation = equation.ToUpper().Replace("MOD", "%");
            try
            {
                string value = new DataTable().Compute(equation, null).ToString();
                bool RealValue = true;
                foreach (char element in value) {
                    if (RealValue == false) { break; }
                    else if (value.Contains(Arith.chars[element]) || Convert.ToInt32(value) > 5000) { RealValue = false; }
                }
                if (RealValue)
                {
                    await Context.Channel.SendMessageAsync(usage);
                }
                else
                {
                    int number = Convert.ToInt32(value);

                    int result = MFuncty.Phi(number);
                        await Context.Channel.SendMessageAsync("Phi of " + value + " is : " + result.ToString());}
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync(usage);
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

        [Command("IntPolygon", RunMode = RunMode.Async)]
        public async Task SumOfInt(int n) {
            usage = "Usage : |IntPolygon <n> . Where n is the number of sides for a polygon and the result is the sum of interior angles.";
            if (!(n < 3))
            {
                int SumOfIntAngle = Arith.IntAngle(n);
                await Context.Channel.SendMessageAsync("The sum of interior angles for a polygon with " + n + " side(s) is : " + SumOfIntAngle.ToString() + " degrees");
            }
            else {
                await Context.Channel.SendMessageAsync(usage);
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

        [Command("Roll", RunMode = RunMode.Async)]
        public async Task RollDeCmd([Remainder]string equation = "1"){
            usage = "Usage : `|Roll <equation>` , where `equation` should return a whole number below 255, and does not contain any functions.";
            int zzz = 1;
            try
            {
                string value = new DataTable().Compute(equation, null).ToString();
                zzz = Convert.ToInt32(value);
            }
            catch (Exception) {
                await Context.Channel.SendMessageAsync(usage);
            }

            if (zzz > 255)
            {
                await Context.Channel.SendMessageAsync(usage);
            }
            else
            {
                byte Number = Convert.ToByte(zzz);

                string directNote = @"C:\Users\Yeo Wen Qin\Documents\Visual Studio 2015\Projects\AliceBot\AliceBot\bin\Release\Notey";
                string textPath = @"C:\Users\Yeo Wen Qin\Documents\Visual Studio 2015\Projects\AliceBot\AliceBot\bin\Release\Notey\numbers.txt";
                FileInfo x = new FileInfo(textPath);

                if (Directory.Exists(directNote) == true){
                    var y = Directory.GetFiles(directNote);
                    foreach (var element in y){
                        int i = 0;
                        File.Delete(y[i]);
                    }
                    while (Directory.GetFiles(directNote).Length != 0) { }
                    Directory.Delete(directNote);
                }

                if (Number == 0 || Number < 0){
                    await Context.Channel.SendMessageAsync("Error: Undefined");
                } else{
                    Directory.CreateDirectory(directNote);
                    for (; Number != 0; Number--){
                        int randnumber = randy.Next(1, 6);
                        bool processing = true;
                        while (processing){
                            try{
                                using (var tw = new StreamWriter(textPath, true)){
                                    await tw.WriteAsync(Convert.ToString(randnumber));
                                    await tw.WriteAsync(" ");

                                    tw.Close();
                                }
                                processing = false;
                            }catch (IOException){
                                processing = true;
                            }
                        }
                    }
                    string result = File.ReadAllText(textPath);
                    await Context.Channel.SendMessageAsync(result);
                    string adding = result.Replace(" ", "");
                    int sum = 0;
                    foreach (char element in adding)
                    {
                        sum += Int32.Parse(element.ToString());
                    }
                    await Context.Channel.SendMessageAsync("The total sum of all the value rolled is : " + sum
                        + newline
                        + "The average value rolled is : " + (Convert.ToInt64(sum)/Convert.ToInt64(zzz)).ToString()
                        );

                    if (Directory.Exists(directNote) == true)
                    {
                        var y = Directory.GetFiles(directNote);
                        foreach (var element in y)
                        {
                            int i = 0;
                            File.Delete(y[i]);
                        }
                        while (Directory.GetFiles(directNote).Length != 0) { }

                        Directory.Delete(directNote);
                    }
                }
            }
        }

                }
}