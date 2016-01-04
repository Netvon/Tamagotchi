using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Console.Model;
using Tamagotchi.Console.TamagotchiService;

namespace Tamagotchi.Console.Controller
{
    class TamagotchiController
    {
        readonly ITamagotchiRepository _repo;

        public TamagotchiController(ITamagotchiRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException(nameof(repo));

            _repo = repo;
        }

        string Header =>
            "================================================================================" +
            "= Tamagotchi Console App - Made by Tom van Nimwegen 2015-2016                  =" +
            "================================================================================";

        string WelcomeMessage =>
            "Hi there! Welcome to the Tamagotchi Console App.";

        string HelpMessage =>
            $"Type [quit] to close the application.{NewLine}" +
            $"Type [view] to view all Tamagotchis.{NewLine}" +
            "Type [add] to create a new Tamagotchi.";

        string NewLine => System.Console.Out.NewLine;

        public void Start()
        { 
            while (true)
            {
                System.Console.Clear();
                WriteHeader();
                WriteLine(WelcomeMessage);

                WriteLine();

                if (!_repo.HasData())
                {
                    WriteLine("A connection error occured", ConsoleColor.Red);
                    AskForInput("Press any ket to continue");
                    return;
                }

                WriteLine(HelpMessage);
                WriteLine();

                string input = AskForInput();

                switch (input)
                {
                    case "view":
                        input = StartView();
                        break;
                    case "add":
                        input = StartAddView();
                        break;
                    case "wereami":
                    case "wai":
                    case "w":
                        WriteLine(_repo.WhereAmI());
                        AskForInput("Press any button to continue");
                        break;
                    default:
                        WriteLine("Command not recognized.", ConsoleColor.Red);
                        AskForInput("Press any button to continue");
                        break;
                }

                if (input == "quit")
                    return;

            }
        }

        string AskForInput(string prompt = "> ")
        {
            Write(prompt);

            var input = ReadLine().ToLower();
            return input;
        }

        string StartView()
        {
            string input = "";

            while (true)
            {
                System.Console.Clear();
                WriteHeader();
                WriteLine("Viewing all Tamagotchis");

                WriteLine();

                WriteLine("Type [quit] to close the application." + NewLine +
                                  "Type [back] to go back to the start." + NewLine +
                                  "Type the name of a Tamagotchi to view it.");

                WriteLine();

                var all = _repo.GetAll();

                foreach (var item in all)
                    WriteLine($" -> [Name: {item.Name}] [Status: {item.Status}]");

                WriteLine();

                input = AskForInput();

                if (input == "quit" || input == "back")
                    break;

                if(input.StartsWith("@", StringComparison.Ordinal))
                    input = input.Substring(1);

                if (all.Any(t => t.Name.ToLower() == input))
                {
                    var output = StartDetailView(all.FirstOrDefault(t => t.Name.ToLower() == input));
                    if (output == "back")
                        continue;

                    if (output == "quit")
                        return output;

                    break;
                }

                WriteLine("Command not recognized.", ConsoleColor.Red);
                AskForInput("Press any button to continue");
            }

            return input;
        }

        string StartDetailView(TamagotchiContract tama)
        {
            if (tama == null)
                return "";

            while (true)
            {
                System.Console.Clear();
                WriteHeader();

                WriteTamagotchiStatus(tama);

                if (tama.IsInCoolDown)
                {
                    WriteLine();
                    WriteLine($"Cooldown in effect until {tama.CoolDownUntilUtc.ToLocalTime()}.");
                    if (tama.CoolDownLeft.Hours > 0)
                        WriteLine($"    Cooldown will take another {tama.CoolDownLeft.Hours} hours {tama.CoolDownLeft.Minutes} minutes and {tama.CoolDownLeft.Seconds} seconds.");
                    else if (tama.CoolDownLeft.Hours == 0 && tama.CoolDownLeft.Minutes > 0)
                        WriteLine($"    Cooldown will take another {tama.CoolDownLeft.Minutes} minutes and {tama.CoolDownLeft.Seconds} seconds.");
                    else if (tama.CoolDownLeft.Hours == 0 && tama.CoolDownLeft.Minutes == 0)
                        WriteLine($"    Cooldown will take another {tama.CoolDownLeft.Seconds} seconds.");
                }

                WriteLine();

                WriteLine("Type [quit] to close the application." + NewLine +
                        "Type [back] to go back to the Tamgotchi overview." + NewLine +
                        "Type [rules] to view the rules for this Tamagotchi." + NewLine +
                        "Type [refresh]/[r] to update this page.");

                if (!tama.IsInCoolDown && !tama.HasDied)
                    WriteLine("Available actions:" + NewLine +
                              "    [eat] [sleep] [play] [workout] [hug]");

                WriteLine();

                string input = AskForInput();

                if (input == "quit" || input == "back")
                    return input;

                switch (input)
                {
                    case "quit":
                    case "back":
                        return input;

                    case "refresh":
                    case "r":
                        tama = _repo.Get(tama.Name);
                        break;

                    case "eat":
                        if (!_repo.Eat(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        tama = _repo.Get(tama.Name);
                        break;

                    case "sleep":
                        if (!_repo.Sleep(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        tama = _repo.Get(tama.Name);
                        break;

                    case "play":
                        if (!_repo.Play(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        tama = _repo.Get(tama.Name);
                        break;

                    case "workout":
                        if (!_repo.Workout(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        tama = _repo.Get(tama.Name);
                        break;

                    case "hug":
                        if (!_repo.Hug(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        tama = _repo.Get(tama.Name);
                        break;

                    case "rule":
                    case "rules":
                        var output = StartRulesView(tama);
                        if (output == "quit")
                            return "quit";

                        tama = _repo.Get(tama.Name);

                        break;

                    default:
                        WriteLine("Command not recognized.", ConsoleColor.Red);
                        AskForInput("Press any button to continue");
                        break;
                }

            }
        }

        string StartAddView()
        {
            while(true)
            {
                System.Console.Clear();
                WriteHeader();

                WriteLine("Type [quit] to close the application.");
                WriteLine("Type [back] to go back to the start.");
                WriteLine("Type a name for the new tamagotchi");

                WriteLine();

                var input = AskForInput();

                if (input == "back" || input == "quit")
                    return input;

                if (input.StartsWith("@", StringComparison.Ordinal))
                    input = input.Substring(1);

                if (_repo.Add(input))
                    return "back";

                WriteLine("Tamagotchi was not added");
                AskForInput("Press any button to continue");

            }
        }

        string StartRulesView(TamagotchiContract tama)
        {
            var rules = tama.Rules;
            var index = 0;

            Func<RuleContract> current = () => rules.ElementAt(index);
            Action next = () => index = (index + 1) % rules.Count();
            Action refresh = () =>
            {
                tama = _repo.Get(tama.ID);
                rules = tama.Rules;
            };

            while(true)
            {
                var rule = current.Invoke();

                System.Console.Clear();
                WriteHeader();

                WriteTamagotchiStatus(tama);

                WriteLine("Type [quit] to close the application.");
                WriteLine("Type [back] to go back to the start.");
                WriteLine("Type [next] to go to the next rule");

                if(rule.IsActive)
                    WriteLine("Type [off] to deactivate the rule");
                else
                    WriteLine("Type [on] to activate the rule");

                WriteLine();
                Write($"[Name: {rule.Name}] [Active: ", ConsoleColor.Gray);

                ConsoleColor color = ConsoleColor.Green;

                if (!rule.IsActive)
                    color = ConsoleColor.Red;

                Write($"{rule.IsActive}", color);
                Write("]", ConsoleColor.Gray);
                WriteLine();

                WriteLine($"Discription:{NewLine}[{rule.Discription}]");
                WriteLine();

                var input = AskForInput();

                if (input == "off")
                {
                    _repo.SetRule(tama.Name, rule.Name, false);
                    refresh.Invoke();
                    continue;
                }

                if (input == "on")
                {
                    _repo.SetRule(tama.Name, rule.Name, true);
                    refresh.Invoke();
                    continue;
                }

                if (input == "next")
                {
                    next.Invoke();
                    continue;
                }

                if (input == "quit" || input == "back")
                    return input;
            }
        }

        void WriteHeader()
        {
            WriteLine(Header, ConsoleColor.Black, ConsoleColor.Gray);
        }

        void WriteTamagotchiStatus(TamagotchiContract tama)
        {
            WriteLine($"Viewing Tamagotchi: {tama.Name} [Status: {tama.Status}]");
            WriteLine($"[Bordedom: {tama.Boredom}] [Health: {tama.Health}] [Hunger: {tama.Hungriness}] [Sleep: {tama.Sleepiness}]");
        }

        void WriteLine(string line = "", ConsoleColor color = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black)
        {
            System.Console.ForegroundColor = color;
            System.Console.BackgroundColor = background;
            System.Console.WriteLine(line);
        }

        void Write(string text, ConsoleColor color = ConsoleColor.Green, ConsoleColor background = ConsoleColor.Black)
        {
            System.Console.ForegroundColor = color;
            System.Console.BackgroundColor = background;
            System.Console.Write(text);
        }

        string ReadLine(ConsoleColor color = ConsoleColor.Green, ConsoleColor background = ConsoleColor.Black)
        {
            System.Console.ForegroundColor = color;
            System.Console.BackgroundColor = background;
            return System.Console.ReadLine();
        }
    }
}
