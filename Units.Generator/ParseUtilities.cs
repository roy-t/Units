namespace Units.Generator
{
    public static class ParseUtilities
    {

        public static string EatWhiteSpace(string line)
        {
            for(var i = 0; i < line.Length; i++)
            {
                if(!char.IsWhiteSpace(line[i]))
                {
                    return line.Substring(i);
                }
            }

            return string.Empty;
        }
    }
}
