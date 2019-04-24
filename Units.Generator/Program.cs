using System;
using System.Collections.Generic;
using System.IO;

namespace Units.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines(args[0]);

            var tokens = new List<IToken>();

            foreach(var line in text)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var remainder = line;
                    remainder = NameDefinitionToken.Parse(remainder, tokens);
                    remainder = SymbolDefinitionToken.Parse(remainder, tokens);
                    remainder = AssignmentToken.Parse(remainder, tokens);
                    remainder = NumberToken.Parse(remainder, tokens);
                    remainder = SymbolToken.Parse(remainder, tokens);
                    tokens.Add(new EndToken());
                }
            }


            Console.ReadLine();
        }
    }
}
