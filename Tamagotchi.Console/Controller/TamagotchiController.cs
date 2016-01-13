using System;
using System.Collections.Generic;
using System.Linq;
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

        string AppName => "Tamagotchi Console App";

        string Header =>
            "================================================================================" +
            "= Tamagotchi Console App - Made by Tom van Nimwegen 2015-2016                  =" +
            "================================================================================";

        string WelcomeMessage =>
            $"Hi there! Welcome to the {AppName}.";

        string HelpMessage =>
            $"Type [quit] to close the application.{NewLine}" +
            $"Type [view] to view all Tamagotchis.{NewLine}" +
            "Type [add] to create a new Tamagotchi.";

        string NewLine => System.Console.Out.NewLine;

        public void Start()
        {
            System.Console.Title = AppName;

            while (true)
            {
                System.Console.Clear();
                WriteHeader();
                WriteLine(WelcomeMessage);

                WriteLine();

                if (!_repo.HasData())
                {
                    ShowConnectionError();
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
                    case "clean":
                    case "c":
                        WriteLine("Removing all dead Tamagotchis, this might take some time.", ConsoleColor.Red);
                        WriteLine();

                        var allCount = _repo.TamagotchiCount();
                        var perPage = _repo.TamagotchiPerPage();
                        int pagecount = allCount / perPage;

                        for (int i = 0; i < allCount; i += perPage)
                        {
                            var all = _repo.GetAll(i);
                            if (all.Count() <= 0)
                                break;

                            if(all.Any(t => t.HasDied))
                            {
                                foreach (var item in all.Where(t => t.HasDied))
                                {
                                    Write(".", ConsoleColor.Red);
                                    _repo.Remove(item.Name);
                                }

                                allCount = _repo.TamagotchiCount();
                                perPage = _repo.TamagotchiPerPage();
                                pagecount = allCount / perPage;

                                i = 0;
                            }                            
                        }
                        break;
                    case "purge":
                    case "p":
                        WriteLine("Removing all Tamagotchis, this might take some time.", ConsoleColor.Red);
                        WriteLine();

                        while(_repo.TamagotchiCount() != 0)
                        {
                            var all = _repo.GetAll(0);

                            foreach (var item in all)
                            {
                                Write(".", ConsoleColor.Red);
                                _repo.Remove(item.Name);
                            }
                        }
                        break;

                    case "bulk":
                    case "b":
                        WriteLine("Bulk adding Tamagotchis", ConsoleColor.Red);
                        int amount = 0;
                        int.TryParse(AskForInput("amount > "), out amount);
                        if (amount <= 0)
                            break;

                        var prefix = AskForInput("prefix > ");
                        if (string.IsNullOrWhiteSpace(prefix))
                            break;

                        for (int i = 0; i < amount; i++)
                        {
                            Write(".", ConsoleColor.Red);
                            _repo.Add($"{prefix} {i}");
                        }

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

        void ShowConnectionError()
        {
            WriteLine("A connection error occured.", ConsoleColor.Red);
            AskForInput("Please restart the application and try again later.");
            Environment.Exit(0);
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

            int page = 0;
            int per_page = _repo.TamagotchiPerPage();
            int all_count = _repo.TamagotchiCount();
            int page_num = 0;

            while (true)
            {
                System.Console.Clear();
                WriteHeader();
                WriteLine("Viewing all Tamagotchis");

                WriteLine();

                WriteLine("Type [quit] to close the application." + NewLine +
                        "Type [back] to go back to the start." + NewLine +
                        "Type the name or # of a Tamagotchi to view it.");

                WriteLine();

                per_page = _repo.TamagotchiPerPage();
                all_count = _repo.TamagotchiCount();

                IEnumerable<TamagotchiContract> all = _repo.GetAll(per_page * page).AsEnumerable();

                if (all_count > 10)
                {
                    page_num = (int)Math.Ceiling(all_count / (double)per_page);
                    WriteLine($"Viewing page: {page + 1}/{page_num} - Total: {all_count}");
                    WriteLine("Type [next]/[prev] to go to the next/previous page.");
                    WriteLine();
                }

                foreach (var item in all)
                    WriteLine($"#{item.ID}: [Name: {item.Name}] [Status: {item.Status}]");

                WriteLine();

                input = AskForInput();

                if (input == "quit" || input == "back")
                    break;

                if (input == "next" && page_num > 1)
                {
                    page++;
                    page %= page_num;
                    continue;
                }

                if (input == "prev" && page_num > 1)
                {
                    page--;
                    if (page < 0)
                        page = page_num - 1;
                    continue;
                }

                if (input.StartsWith("@", StringComparison.Ordinal))
                    input = input.Substring(1);

                var tama = all.FirstOrDefault(t => t.Name.ToLower() == input);
                if (tama == null)
                    tama = all.FirstOrDefault(t => t.ID.ToString() == input);

                if (tama != null)
                {
                    var output = StartDetailView(tama);
                    if (output == "back")
                        continue;

                    if (output == "quit")
                        return output;

                    WriteLine("Tamagotchi not found.", ConsoleColor.Red);
                    AskForInput("Press any button to continue");

                    break;
                }

                if (tama == null)
                {
                    WriteLine("Tamagotchi not found.", ConsoleColor.Red);
                    AskForInput("Press any button to continue");
                    continue;
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

                if (tama.HasDied)
                    WriteLine("Type [delete] to delete this Tamagotchi.");

                if (!tama.IsInCoolDown && !tama.HasDied)
                    WriteLine("Available actions:" + NewLine +
                              "    [eat] [sleep] [play] [workout] [hug]");

                WriteLine();

                try { _repo.HasData(); }
                catch (Exception) { ShowConnectionError(); }

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
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "eat":
                        if (!_repo.Eat(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "sleep":
                        if (!_repo.Sleep(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "play":
                        if (!_repo.Play(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "workout":
                        if (!_repo.Workout(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "hug":
                        if (!_repo.Hug(tama.Name))
                            AskForInput("Action not available, press any button to continue");
                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        break;

                    case "rule":
                    case "rules":
                        var output = StartRulesView(tama);
                        if (output == "quit")
                            return "quit";

                        try { tama = _repo.Get(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }

                        break;

                    case "delete":
                    case "remove":
                    case "d":
                        if (!tama.HasDied)
                        {
                            WriteLine("Alive Tamagotchis cannot be deleted.", ConsoleColor.Red);
                            AskForInput("Press any button to continue");
                            break;
                        }

                        try { _repo.Remove(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }

                        return "back";

                    case "delete -g":
                    case "remove -g":
                    case "d -g":
                        try { _repo.Remove(tama.Name); }
                        catch (Exception) { ShowConnectionError(); }
                        return "back";

                    default:
                        WriteLine("Command not recognized.", ConsoleColor.Red);
                        AskForInput("Press any button to continue");
                        break;
                }

            }
        }

        string StartAddView()
        {
            while (true)
            {
                System.Console.Clear();
                WriteHeader();

                WriteLine("Type [quit] to close the application.");
                WriteLine("Type [back] to go back to the start.");
                WriteLine("Type a name for the new tamagotchi");

                WriteLine();

                try { _repo.HasData(); }
                catch (Exception) { ShowConnectionError(); }

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

            while (true)
            {
                var rule = current.Invoke();

                System.Console.Clear();
                WriteHeader();

                WriteTamagotchiStatus(tama);

                WriteLine("Type [quit] to close the application.");
                WriteLine("Type [back] to go back to the start.");
                WriteLine("Type [next] to go to the next rule");

                if (rule.IsActive)
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

                try { _repo.HasData(); }
                catch (Exception) { ShowConnectionError(); }

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
            if (!tama.HasDied)
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
