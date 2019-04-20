﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsole
    {
        public bool KeyAvailable => Console.KeyAvailable;

        public void Clear() => Console.Clear();

        public void WriteLine(string message) => Console.WriteLine(message);

        public void Write(string message) => Console.Write(message);

        public string ReadLine() => Console.ReadLine();

        public ConsoleKey ReadKey(bool intercept) => Console.ReadKey(intercept).Key;
    }
}
