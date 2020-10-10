﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Filemanager
{
    class Display
    {
        protected void WriteOut(IEnumerable<Tuple<FileSystemInfo, string>> listToWrite)
        {
            Console.WriteLine();

            foreach (var item in listToWrite)
            {
                if (item.Item1 is DirectoryInfo || item.Item1 == null)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(SplitFileSystemInfo(item.Item2));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(SplitFileSystemInfo(item.Item2));
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }

        protected void ClearLine()
        {
            var currentLineCursor = Console.CursorTop;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        protected string SplitFileSystemInfo(string name)
        {
            var splitted = name.Split('\\').Reverse();

            if (splitted.ElementAt(0) != "")
                return splitted.ElementAt(0);

            return splitted.ElementAt(1);
        }
    }
}
