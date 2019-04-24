using System.Collections.Generic;

namespace Units.Generator
{
    public sealed class AssignmentToken : IToken
    {
        public AssignmentToken()
        {            
        }        

        public static string Parse(string input, List<IToken> tokens)
        {
            var token = ParseUtilities.EatWhiteSpace(input);
            var position = token.IndexOf(':');
            if (position == 0)
            {
                tokens.Add(new AssignmentToken());
                return token.Substring(position + 1);
            }

            return input;
        }

        public override string ToString() => ":";

    }
}
