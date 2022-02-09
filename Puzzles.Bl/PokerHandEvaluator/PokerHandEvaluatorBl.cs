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



			//foreach (var player in players)
			//{
			//	if (player.PlayerName == "Rob")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadFullHouse();
			//	}
			//	if (player.PlayerName == "Jaz")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadFlush();
			//	}
			//	if (player.PlayerName == "Molly")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadFourOfAKind();
			//	}
			//	if (player.PlayerName == "Spencer")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadPair();
			//	}
			//	if (player.PlayerName == "Turner")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadRoyalFlush();
			//	}
			//	if (player.PlayerName == "Ben")
			//	{
			//		player.PokerHand.Cards = DeckOfCardsExtensions.LoadStraightFlush();
			//	}
			//}
			//now the cards have been dealt and we know they are unique. now need to decide who has the best hand


			foreach (var player in players)
			{

				//if (player.PlayerName == "Molly")
				//{
				//	Console.WriteLine("hey");
				//}
				player.PokerHand.HandType = _GetHandTypeByHandModel(player.PokerHand);

				if (player.PokerHand.HandType == AvailablePokerHands.HighCard)
				{
					player.PokerHand.HighCardString = _HighCardDisplayString(player.PokerHand);
				}

			}


			var updatedplayerslist = _GetWinningPlayers(players);

			//now need to see if any of the players have the same hand... 
			var winningplayers = updatedplayerslist.Where(x => x.WinningHand).ToList();

			if (winningplayers.Count > 1)
			{
				//need to evaluate the difference.
				foreach (var winningplayer in winningplayers)
				{
					var handtype = winningplayer.PokerHand.HandType;
					var highcard = _HighestPokerCardUsedInWinningHand(winningplayer.PokerHand);
					winningplayer.HighestCardInWinningHand = highcard;
				}


				var finalwinningplayer = new PokerPlayerModel();
				var highvalueplaceholder = 0;
				foreach (var wp in winningplayers)
				{
					if ((int)wp.HighestCardInWinningHand.CardValue > highvalueplaceholder)
					{
						finalwinningplayer = wp;
						highvalueplaceholder = (int)wp.HighestCardInWinningHand.CardValue;
					}
				}

				// we have now looped through all the 'winners' 
				// i want to wipe all the 'winning hands' and use the one with the highest winning card
				_RemoveAllWinningHands(players);

				foreach (var player in players)
				{
					if (player.PlayerName == finalwinningplayer.PlayerName)
					{
						player.WinningHand = true;
					}
				}


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
		//TOO- Sometimes two of a certin card can sneak in. need to write unit tests thorougly test this
		private void _GetPlayersPokerHand(PokerPlayerModel player, List<PokerCard> cards, List<PokerCard> takencards)
		{
			//var availablecards = newdeckofcards.Except(takencards).ToList();
			var availablecards =
					cards.Where(p => takencards.All(p2 => p2.UniqueKey != p.UniqueKey)).ToList();

			var playercards = new List<PokerCard>();
			var randomindexes = _DrawFiveRandomNumbers(availablecards);

			foreach (var index in randomindexes)
			{
				var card = new PokerCard();
				card = availablecards[index];

				if (playercards.Any(x => x.UniqueKey == card.UniqueKey))
				{
					throw new PuzzlesApplicationException($"No duplicate cards");
				}

				playercards.Add(card);
				takencards.Add(card);
			}

			player.PokerHand.Cards = playercards;
		}

		private List<int> _DrawFiveRandomNumbers(List<PokerCard> cards)
		{
			//var resultnumbers = new List<int>();
			Random rnd = new Random();

			//for (int j = 0; j < 5; j++)
			//{
			//	resultnumbers.Add(rnd.Next(cards.Count));
			//}


			List<int> listNumbers = new List<int>();
			int number;
			for (int j = 0; j < 5; j++)
			{
				do
				{
					number = rnd.Next(cards.Count);
				} while (listNumbers.Contains(number));
				listNumbers.Add(number);
			}


			return listNumbers;
		}




		#endregion



		#region Rank Cards / Hand

		private AvailablePokerHands _GetHandTypeByHandModel(PokerHandModel hand)
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



		private string _HighCardDisplayString(PokerHandModel hand)
		{
			//var cards = hand.Cards.OrderBy(x => x.CardValue).ToList();
			var biggestcard = hand.Cards.Max(x => x.CardValue);
			return $"{biggestcard} High";
		}



		/// <summary>
		/// returns all the players. but the master list of players will have the 'WinningHand' bool set to true
		/// </summary>
		/// <param name="players"></param>
		/// <returns></returns>
		private List<PokerPlayerModel> _GetWinningPlayers(List<PokerPlayerModel> players)
		{
			var winninghand = players.Max(x => x.PokerHand.HandType);
			var playersthatwon = players.Where(x => x.PokerHand.HandType == winninghand).ToList(); ;


			foreach (var player in players)
			{
				//var match = playersthatwon.Select(x => x.PlayerName == player.PlayerName).ToList();
				var match = playersthatwon.Any(x => x.PlayerName == player.PlayerName);

				if (match)
				{
					player.WinningHand = true;
				}

			}

			return players;
		}




		private PokerCard _HighestPokerCardUsedInWinningHand(PokerHandModel hand)
		{
			switch (hand.HandType)
			{
				//todo - need to finish all the cases for split pots. its rare enough I want to end here


				case AvailablePokerHands.ThreeOfAKind:
					return _HighCardForThreeOfKind(hand);


				case AvailablePokerHands.TwoPair:
					return _HighCardForPairHand(hand);

				case AvailablePokerHands.Pair:
					return _HighCardForPairHand(hand);


					var highcard = hand.Cards.HighestCard();
					return highcard;
			}

			return new PokerCard();
		}




		private PokerCard _HighCardForPairHand(PokerHandModel hand)
		{
			var cardsused = new List<PokerCard>();
			foreach (var card in hand.Cards)
			{
				var iscardused = card.IsCardUsedInPair(hand.Cards);

				if (iscardused)
				{
					cardsused.Add(card);
				}
			}


			var highcard = cardsused.HighestCard();
			return highcard;
		}



		private PokerCard _HighCardForThreeOfKind(PokerHandModel hand)
		{
			var cardsused = new List<PokerCard>();
			foreach (var card in hand.Cards)
			{
				var iscardused = card.IsCardUsedInThreeOfAKind(hand.Cards);

				if (iscardused)
				{
					cardsused.Add(card);
				}
			}


			var highcard = cardsused.HighestCard();
			return highcard;
		}





		private void _RemoveAllWinningHands(List<PokerPlayerModel> players)
		{
			foreach (var player in players)
			{
				player.WinningHand = false;
			}
		}
		#endregion

	}
}
