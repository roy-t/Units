using System.Collections.Generic;

namespace Units.Generator
{
    public sealed class SymbolToken : IToken
    {
        public SymbolToken(string symbol)
        {
            this.Symbol = symbol;
        }

        public string Symbol { get; }

        public static string Parse(string input, List<IToken> tokens)
        {
            var token = ParseUtilities.EatWhiteSpace(input);
            var length = token.IndexOf(' ') > 0 ? token.IndexOf(' ') : token.Length;
            if (token.Length > 0 && char.IsLetter(token[0]))
            {
                tokens.Add(new SymbolToken(input.Substring(0, length)));
                return token.Substring(length);
            }

            return input;
        }

        public override string ToString() => this.Symbol;
    }
}
