using System.ComponentModel.DataAnnotations;

namespace Puzzles.Bl.Enumerations
{
	public enum AvailablePokerHands
	{
		[Display(Name = "High Card")] HighCard = 1,
		[Display(Name = "Pair")] Pair = 2,
		[Display(Name = "Two Pair")] TwoPair = 3,
		[Display(Name = "Three of a Kind")] ThreeOfAKind = 4,
		[Display(Name = "Straight")] Straight = 5,
		[Display(Name = "Flush")] Flush = 6,
		[Display(Name = "Full House")] FullHouse = 7,
		[Display(Name = "Four of a Kind")] FourOfAKind = 8,
		[Display(Name = "Straight Flush")] StraightFlush = 9,
		[Display(Name = "Royal Flush")] RoyalFlush = 10,
		//[Display(Name = "Royal Flush")] RoyalFlush = 10,
	}
}
