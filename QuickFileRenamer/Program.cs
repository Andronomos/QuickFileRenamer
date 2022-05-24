using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuickFileRenamer
{
    class Program
    {
        private static readonly RenamerSettings _settings = new RenamerSettings();
        private static readonly Random _rand = new Random();

        static void Main(string[] args)
        {
            string workPath = Environment.CurrentDirectory;
            
            if (args.Length != 0)
                if (Directory.Exists(args[0]))
                    workPath = args[0];

            Console.WriteLine($"Renaming files in {workPath}");

            string[] files = Directory.GetFiles(workPath, "*.*")
                .Where(s => _settings.Extensions.Any(e => s.EndsWith(e, StringComparison.OrdinalIgnoreCase))).ToArray();

            RenameFiles(files);
        }

        private static void RenameFiles(string[] files)
        {
            foreach (string file in files)
            {
                if(Path.GetFileNameWithoutExtension(file).Length == _settings.NewFileNameLength)
                {
                    continue;
                }

                File.Move(file, @$"{_settings.WorkPath}\{GenerateFileName(_settings.Characters, _settings.NewFileNameLength)}{Path.GetExtension(file)}");
            }
        }

        private static string GenerateFileName(char[] charset, int fileNameLength)
        {
            char[] newFileName = new char[fileNameLength];

            for (int i = 0; i < fileNameLength; i++)
            {
                newFileName[i] = charset[_rand.Next(fileNameLength)];
            }

            return new string(newFileName);
        }
    }
}
