using System.ComponentModel.DataAnnotations;

namespace Puzzles.Bl.Enumerations
{
  public enum CardSuits
  {
    [Display(Name = "Clubs")] Clubs = 1,
    [Display(Name = "Diamonds")] Diamonds = 2,
    [Display(Name = "Hearts")] Hearts = 3,
    [Display(Name = "Spades")] Spades = 4,
  }
}
