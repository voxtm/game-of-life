﻿using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace GameOfLife.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class FileWrapper : IFile
    {
        public string ReadAllText(string path) => File.ReadAllText(path);
    }
}
