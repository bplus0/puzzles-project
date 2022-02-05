namespace Puzzles.Bl.Extensions
{
  public static class IntExtensions
  {
    public static int ReverseInt(this int num)
    {
      int result = 0;
      while (num > 0)
      {
        result = result * 10 + num % 10;
        num /= 10;
      }
      return result;
    }
  }
}
