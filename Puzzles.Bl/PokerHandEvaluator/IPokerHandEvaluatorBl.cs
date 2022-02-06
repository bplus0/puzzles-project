using Puzzles.Bl.PokerHandEvaluator.Models;

namespace Puzzles.Bl.PokerHandEvaluator
{
  public interface IPokerHandEvaluatorBl
  {
    Task<PokerHandEvaluatorHomeModel> GetTableCardsAsync(int numofplayers = 6);
  }
}
