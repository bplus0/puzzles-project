using Puzzles.Bl.PokerHandEvaluator.Models;

namespace Puzzles.Bl.PokerHandEvaluator
{
  public class PokerHandEvaluatorBl : IPokerHandEvaluatorBl
  {
    public PokerHandEvaluatorBl()
    {

    }



    /// <summary>
    /// no db. and i gotta stop sometime. gonna hardcode the players
    /// </summary>
    /// <param name="numofplayers"></param>
    /// <returns></returns>
    public async Task<PokerHandEvaluatorHomeModel> GetTableCardsAsync(int numofplayers = 6)
    {
      var result = new PokerHandEvaluatorHomeModel();

      result.PokerPlayers.Add(CreateNewPokerPlayer("Ben"));
      result.PokerPlayers.Add(CreateNewPokerPlayer("Rob"));
      result.PokerPlayers.Add(CreateNewPokerPlayer("Jaz"));
      result.PokerPlayers.Add(CreateNewPokerPlayer("Molly"));
      result.PokerPlayers.Add(CreateNewPokerPlayer("Spencer"));
      result.PokerPlayers.Add(CreateNewPokerPlayer("Turner"));


      var newdeckofcards = DeckOfCardsExtensions.LoadNewDeck();

      foreach (var card in newdeckofcards)
      {

      }



      var benscards = new List<PokerCard>();
      var random = new Random();
      int randomindex = random.Next(newdeckofcards.Count);

      benscards.Add(newdeckofcards[randomindex]);
      newdeckofcards.RemoveAt(randomindex);



      return result;
    }


    private PokerPlayerModel CreateNewPokerPlayer(string name)
    {
      var pokerplayerone = new PokerPlayerModel();
      pokerplayerone.PlayerName = name;
      //pokerplayerone.PokerHand = GetNewPokerHand();
      return pokerplayerone;


    }



  }
}
