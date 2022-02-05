using Puzzles.Bl.PalindromeChecker.Models;

namespace Puzzles.Bl.PalindromeChecker
{
  public interface IPalindromeCheckerBl
  {
    Task<PalindromeCheckerModel> SubmitCheckPalindromeCheckerModelAsync(PalindromeCheckerModel model);
  }
}
