namespace Puzzles.Bl.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
    }
}
