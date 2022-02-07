using Puzzles.Bl.Enumerations;
using Puzzles.Bl.Exceptions;
using Puzzles.Bl.Extensions;
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


			var players = _LoadPokerPlayers();


			var newdeckofcards = DeckOfCardsExtensions.LoadNewDeck();
			var takencards = new List<PokerCard>();

			foreach (var player in players)
			{
				_GetPlayersPokerHand(player, newdeckofcards, takencards);
			}


			//now the cards have been dealt and we know they are unique. now need to decide who has the best hand


			foreach (var player in players)
			{
				var handtype = _AnalyzeHand(player.PokerHand);
				player.PokerHand.HandType = handtype;
			}




			result.PokerPlayers = players;
			return result;
		}


		#region Players
		private List<PokerPlayerModel> _LoadPokerPlayers()
		{
			var players = new List<PokerPlayerModel>();

			players.Add(_CreateNewPokerPlayer("Ben"));
			players.Add(_CreateNewPokerPlayer("Rob"));
			players.Add(_CreateNewPokerPlayer("Jaz"));
			players.Add(_CreateNewPokerPlayer("Molly"));
			players.Add(_CreateNewPokerPlayer("Spencer"));
			players.Add(_CreateNewPokerPlayer("Turner"));

			return players;
		}


		private PokerPlayerModel _CreateNewPokerPlayer(string name)
		{
			var pokerplayerone = new PokerPlayerModel();
			pokerplayerone.PlayerName = name;
			//pokerplayerone.PokerHand = GetNewPokerHand();
			return pokerplayerone;


		}


		#endregion



		#region  Deal Cards
		private void _GetPlayersPokerHand(PokerPlayerModel player, List<PokerCard> cards, List<PokerCard> takencards)
		{
			var availablecards = cards.Except(takencards).ToList();

			var playercards = new List<PokerCard>();
			var randomindexes = _DrawFiveRandomNumbers(availablecards);

			foreach (var index in randomindexes)
			{
				var card = new PokerCard();
				card = availablecards[index];
				playercards.Add(card);
				takencards.Add(card);


			}

			player.PokerHand.Cards = playercards;
		}

		private List<int> _DrawFiveRandomNumbers(List<PokerCard> cards)
		{
			var resultnumbers = new List<int>();
			Random rnd = new Random();

			for (int j = 0; j < 5; j++)
			{
				resultnumbers.Add(rnd.Next(cards.Count));
			}


			return resultnumbers;
		}

		private void _AssignPlayerCards()
		{

		}


		#endregion



		#region Rank Cards / Hand

		private AvailablePokerHands _AnalyzeHand(PokerHandModel hand)
		{
			if (hand.Cards.Count != 5)
			{
				throw new PuzzlesApplicationException($"Insufficient Cards For Player ");
			}

			//this will be ugly


			if (hand.Cards.IsRoyalFlush())
			{
				return AvailablePokerHands.RoyalFlush;
			}



			if (hand.Cards.IsStraightFlush())
			{
				return AvailablePokerHands.StraightFlush;
			}

			if (hand.Cards.IsFourOfAKind())
			{
				return AvailablePokerHands.FourOfAKind;
			}

			if (hand.Cards.IsFullHouse())
			{
				return AvailablePokerHands.FullHouse;
			}

			if (hand.Cards.IsFlush())
			{
				return AvailablePokerHands.Flush;
			}


			if (hand.Cards.IsStraight())
			{
				return AvailablePokerHands.Straight;
			}

			if (hand.Cards.IsThreeOfAKind())
			{
				return AvailablePokerHands.ThreeOfAKind;
			}


			if (hand.Cards.IsTwoPair())
			{
				return AvailablePokerHands.TwoPair;
			}


			if (hand.Cards.IsPair())
			{
				return AvailablePokerHands.Pair;
			}

			return AvailablePokerHands.HighCard;
			//throw new PuzzlesApplicationException($"Unable to figure out the hand type.");

		}


		#endregion

	}
}
