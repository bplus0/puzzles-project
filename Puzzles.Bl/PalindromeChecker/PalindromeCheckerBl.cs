using Puzzles.Bl.Exceptions;
using Puzzles.Bl.Extensions;
using Puzzles.Bl.PalindromeChecker.Models;

namespace Puzzles.Bl.PalindromeChecker
{
  public class PalindromeCheckerBl : IPalindromeCheckerBl
  {
    public PalindromeCheckerBl()
    {

    }

    public async Task<PalindromeCheckerModel> SubmitCheckPalindromeCheckerModelAsync(PalindromeCheckerModel model)
    {
      if (model.NumberToCheck <= 0)
      {
        throw new PuzzlesApplicationException($"Please enter a positive number greater than zero");
      }

      var numbertocheck = model.NumberToCheck;

      var reversednumber = model.NumberToCheck.ReverseInt();


      if (numbertocheck.Equals(reversednumber))
      {
        model.ReturnMessage = $"Boom. We have a palindrome.";
        model.PalindromeFound = true;
      }
      else
      {
        model.ReturnMessage = "No palindrome. Try again";
        model.PalindromeFound = false;
      }

      return model;
    }
  }
}
