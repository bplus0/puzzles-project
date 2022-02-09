namespace Puzzles.Bl.PokerHandEvaluator.Models
{
	public class PokerPlayerModel
	{
		public string PlayerName { get; set; }
		public PokerHandModel PokerHand { get; set; } = new PokerHandModel();
		public bool WinningHand { get; set; } = false;

		public PokerCard HighestCardInWinningHand { get; set; }

	}
}