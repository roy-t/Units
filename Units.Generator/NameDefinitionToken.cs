using System.Collections.Generic;

namespace Units.Generator
{
    public sealed class NameDefinitionToken : IToken
    {
        public NameDefinitionToken(string name)
        {
            this.Name = name;
        }

        public string Name { get; }


        public static string Parse(string input, List<IToken> tokens)
        {
            var token = ParseUtilities.EatWhiteSpace(input);
            var length = token.IndexOf(' ') > 0 ? token.IndexOf(' ') : token.Length;
            if(token.Length > 0 &&  char.IsLetter(token[0]))
            {
                tokens.Add(new NameDefinitionToken(input.Substring(0, length)));
                return token.Substring(length);
            }

            return input;
        }

        public override string ToString() => this.Name;

    }
}
