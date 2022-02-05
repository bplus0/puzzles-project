namespace Puzzles.Bl.PalindromeChecker.Models
{
  public class PalindromeCheckerModel
  {
    public int NumberToCheck { get; set; }
    public bool Saved { get; set; }
    public bool PalindromeFound { get; set; }
    public string ReturnMessage { get; set; }

    public string PreviousGuesses { get; set; }
  }
}