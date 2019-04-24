using System.Collections.Generic;

namespace Units.Generator
{
    public sealed class SymbolDefinitionToken : IToken
    {
        public SymbolDefinitionToken(string symbol)
        {
            this.Symbol = symbol;
        }

        public string Symbol { get; }

        public static string Parse(string input, List<IToken> tokens)
        {
            var token = ParseUtilities.EatWhiteSpace(input);

            var startPosition = token.IndexOf('(');
            var endPosition = token.IndexOf(')');
            if(startPosition == 0 && endPosition > (startPosition + 1))
            {
                tokens.Add(new SymbolDefinitionToken(token.Substring(startPosition, endPosition - startPosition + 1).Trim(new char[] { '(', ')' })));
                return token.Substring(endPosition + 1);
            }

            return input;
        }

        public override string ToString() => this.Symbol;
    }
}
