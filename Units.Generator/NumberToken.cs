using System.Collections.Generic;

namespace Units.Generator
{
    public sealed class NumberToken : IToken
    {
        public NumberToken(double number)
        {
            this.Number = number;
        }

        public double Number { get; }

        public static string Parse(string input, List<IToken> tokens)
        {
            var token = ParseUtilities.EatWhiteSpace(input);

            var start = 0;
            var length = 0;
            for (var i = 1; i <= token.Length; i++)
            {
                if (double.TryParse(token.Substring(0, i), out var number))
                {
                    length = i;
                }
            }

            if (length > start)
            {
                tokens.Add(new NumberToken(double.Parse(token.Substring(0, length))));
                return token.Substring(length);
            }

            return input;
        }

        public override string ToString() => this.Number.ToString();
    }
}
