using Puzzles.Bl.Enumerations;

namespace Puzzles.Bl.PokerHandEvaluator.Models
{
	public class PokerHandModel
	{
		public List<PokerCard> Cards { get; set; } = new List<PokerCard>();

		public AvailablePokerHands HandType { get; set; }

		public int HandRank { get; set; }
		public string HighCardString { get; set; }
	}
}