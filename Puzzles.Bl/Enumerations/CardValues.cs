using System.ComponentModel.DataAnnotations;

namespace Puzzles.Bl.Enumerations
{
  public enum CardValues
  {
    [Display(Name = "Two")] Two = 2,
    [Display(Name = "Three")] Three = 3,
    [Display(Name = "Four")] Four = 4,
    [Display(Name = "Five")] Five = 5,
    [Display(Name = "Six")] Six = 6,
    [Display(Name = "Seven")] Seven = 7,
    [Display(Name = "Eight")] Eight = 8,
    [Display(Name = "Nine")] Nine = 9,
    [Display(Name = "Ten")] Ten = 10,
    [Display(Name = "Jack")] Jack = 11,
    [Display(Name = "Queen")] Queen = 12,
    [Display(Name = "King")] King = 13,
    [Display(Name = "Ace")] Ace = 14
  }
}
