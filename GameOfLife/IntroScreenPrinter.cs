﻿using System.Collections.Generic;
using GameOfLife.Wrappers;
using System.Globalization;
using System.IO;

namespace GameOfLife
{
    public class IntroScreenPrinter : IIntroScreenPrinter
    {
        private readonly IConsole _console;

        public IntroScreenPrinter(IConsole console)
        {
            _console = console;
        }

        public void PrintNewGameScreen(IReadOnlyList<string> fileNames)
        {
            PrintIntroText();
            PrintPatternsFromFilesOptions(fileNames);
            PrintOptionRandom(fileNames);
            PrintChoiceText();
        }

        private void PrintIntroText()
        {
            _console.Clear();
            _console.WriteLine(string.Empty);
            _console.WriteLine("CONWAY'S GAME OF LIFE");
            _console.WriteLine(string.Empty);
            _console.WriteLine("In this game tiles die and come alive with every generation.");
            _console.WriteLine("Dead tile will come alive if it has exactly 3 alive neighbours.");
            _console.WriteLine("Alive tile will die of loneliness if it has 0 or 1 alive neighbours.");
            _console.WriteLine("Alive tile will also die of overcrowding if it has more than 3 alive neighbours.");
            _console.WriteLine("You can read more about the game at https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life");
            _console.WriteLine(string.Empty);
            _console.WriteLine(
                "Choose a pattern or create a pattern yourself (save it in a .txt file in the patterns folder)");
            _console.WriteLine($"Use \"{Constants.AliveChar}\" for alive tiles and \"{Constants.DeadChar}\" for dead tiles.");
            _console.WriteLine(string.Empty);
        }

        private void PrintPatternsFromFilesOptions(IReadOnlyList<string> fileNames)
        {
            for (var i = 0; i < fileNames.Count; i++)
            {
                PrintPatternFromFileOption(i, fileNames);
            }
        }

        private void PrintOptionRandom(IReadOnlyCollection<string> fileNames) => _console.WriteLine($"{fileNames.Count + 1}: Random");

        private void PrintChoiceText() => _console.WriteLine("Enter number to load board or Escape for Exit.");
        
        private void PrintPatternFromFileOption(int i, IReadOnlyList<string> fileNames)
            => _console.WriteLine($"{i + 1}: {Path.GetFileNameWithoutExtension(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fileNames[i]))}");
    }
}