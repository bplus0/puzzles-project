using System.ComponentModel.DataAnnotations;

namespace Puzzles.Bl.PalindromeChecker.Models
{
  public class PalindromeCheckerModel
  {

    [Display(Name = "Enter a Number")]
    public int NumberToCheck { get; set; }
    public bool Saved { get; set; }
    public bool PalindromeFound { get; set; }
    public string ReturnMessage { get; set; }


    [Microsoft.AspNetCore.Mvc.HiddenInput]
    public string PreviousGuesses { get; set; }
  }
}