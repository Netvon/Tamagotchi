﻿using System;
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
                    WriteLine("A connection error occured", ConsoleColor.Red);
                    AskForInput("Press any key to continue");
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

            int page = 0;
            int per_page = 10;
            int all_count = 0;
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

                var all = _repo.GetAll().AsEnumerable();
                all_count = all.Count();

                if (all_count > 10)
                {
                    page_num = (int)Math.Ceiling(all_count / (double)per_page);
                    WriteLine($"Viewing page: {page + 1}/{page_num} - Total: {all_count}");
                    WriteLine("Type [next]/[prev] to go to the next/previous page.");
                    WriteLine();

                    all = all.Skip(per_page * page).Take(per_page);
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
                        page = page_num -1;
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

                if(tama == null)
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

                    case "delete":
                    case "remove":
                    case "d":
                        if (!tama.HasDied)
                        {
                            WriteLine("Alive Tamagotchis cannot be deleted.", ConsoleColor.Red);
                            AskForInput("Press any button to continue");
                            break;
                        }

                        _repo.Remove(tama.Name);
                        return "back";

                    case "delete -g":
                    case "remove -g":
                    case "d -g":
                        _repo.Remove(tama.Name);
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
