namespace Strategy.Common.Extensions
{
    public static class StringExtensions
    {
        public static string? Capitalize(this string input) 
        {
            if (input.Length == 0)
            {
                return null;
            }
            else if (input.Length == 1)
            {
                return char.ToUpper(input[0]).ToString();
            }
            else
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }
        }
    }
}
