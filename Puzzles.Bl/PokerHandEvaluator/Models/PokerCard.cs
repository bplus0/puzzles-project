using Puzzles.Bl.Enumerations;

namespace Puzzles.Bl.PokerHandEvaluator.Models
{
	public class PokerCard
	{
		public PokerCard()
		{

		}

		public PokerCard(CardSuits suit, CardValues value)
		{
			CardSuit = suit;
			CardValue = value;
		}

		public CardSuits CardSuit { get; set; }
		public CardValues CardValue { get; set; }

		public string UniqueKey => $"{CardValue}{CardSuit}";
	}
}