using Puzzles.Bl.Enumerations;
using Puzzles.Bl.PokerHandEvaluator.Models;

namespace Puzzles.Bl.PokerHandEvaluator
{
	public class DeckOfCards
	{
		public List<PokerCard> DefaultDeck { get; set; } = new List<PokerCard>();


	}


	public static class DeckOfCardsExtensions
	{
		public static List<PokerCard> LoadNewDeck()
		{
			var result = new List<PokerCard>();

			//load them from top to bottom
			//clubs
			var clubs = LoadDecksBySuit(CardSuits.Clubs);
			var diamonds = LoadDecksBySuit(CardSuits.Diamonds);
			var hearts = LoadDecksBySuit(CardSuits.Hearts);
			var spades = LoadDecksBySuit(CardSuits.Spades);

			result.AddRange(clubs);
			result.AddRange(diamonds);
			result.AddRange(hearts);
			result.AddRange(spades);

			return result;
		}



		public static PokerCard NewCardBySuitByValue(CardSuits suit, CardValues value)
		{
			var card = new PokerCard();
			card.CardSuit = suit;
			card.CardValue = value;
			return card;
		}




		public static List<PokerCard> LoadDecksBySuit(CardSuits suit)
		{
			var cards = new List<PokerCard>();
			var two = NewCardBySuitByValue(suit, CardValues.Two);
			var three = NewCardBySuitByValue(suit, CardValues.Three);
			var four = NewCardBySuitByValue(suit, CardValues.Four);
			var five = NewCardBySuitByValue(suit, CardValues.Five);
			var six = NewCardBySuitByValue(suit, CardValues.Six);
			var seven = NewCardBySuitByValue(suit, CardValues.Seven);
			var eight = NewCardBySuitByValue(suit, CardValues.Eight);
			var nine = NewCardBySuitByValue(suit, CardValues.Nine);
			var ten = NewCardBySuitByValue(suit, CardValues.Ten);
			var jack = NewCardBySuitByValue(suit, CardValues.Jack);
			var queen = NewCardBySuitByValue(suit, CardValues.Queen);
			var king = NewCardBySuitByValue(suit, CardValues.King);
			var ace = NewCardBySuitByValue(suit, CardValues.Ace);

			cards.Add(two);
			cards.Add(three);
			cards.Add(four);
			cards.Add(five);
			cards.Add(six);
			cards.Add(seven);
			cards.Add(eight);
			cards.Add(nine);
			cards.Add(ten);
			cards.Add(jack);
			cards.Add(queen);
			cards.Add(king);
			cards.Add(ace);

			return cards;
		}





		#region Testing Methods
		public static List<PokerCard> LoadSixTestHands()
		{
			var result = new List<PokerCard>();



			return result;
		}

		public static List<PokerCard> LoadPair()
		{
			var one = NewCardBySuitByValue(CardSuits.Clubs, CardValues.Four);
			var two = NewCardBySuitByValue(CardSuits.Spades, CardValues.Four);
			var three = NewCardBySuitByValue(CardSuits.Spades, CardValues.Three);
			var four = NewCardBySuitByValue(CardSuits.Spades, CardValues.Seven);
			var five = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Jack);

			var result = new List<PokerCard>();
			result.Add(one);
			result.Add(two);
			result.Add(three);
			result.Add(four);
			result.Add(five);

			return result;
		}

		public static List<PokerCard> LoadTwoPair()
		{
			var one = NewCardBySuitByValue(CardSuits.Clubs, CardValues.Two);
			var two = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Two);
			var three = NewCardBySuitByValue(CardSuits.Diamonds, CardValues.Nine);
			var four = NewCardBySuitByValue(CardSuits.Spades, CardValues.Nine);
			var five = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Eight);

			var result = new List<PokerCard>();
			result.Add(one);
			result.Add(two);
			result.Add(three);
			result.Add(four);
			result.Add(five);

			return result;
		}


		public static List<PokerCard> LoadThreeOfAKind()
		{
			var one = NewCardBySuitByValue(CardSuits.Clubs, CardValues.Two);
			var two = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Two);
			var three = NewCardBySuitByValue(CardSuits.Diamonds, CardValues.Two);
			var four = NewCardBySuitByValue(CardSuits.Spades, CardValues.King);
			var five = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Eight);

			var result = new List<PokerCard>();
			result.Add(one);
			result.Add(two);
			result.Add(three);
			result.Add(four);
			result.Add(five);

			return result;
		}
		public static List<PokerCard> LoadStraight()
		{
			var one = NewCardBySuitByValue(CardSuits.Clubs, CardValues.Four);
			var two = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Five);
			var three = NewCardBySuitByValue(CardSuits.Spades, CardValues.Six);
			var four = NewCardBySuitByValue(CardSuits.Spades, CardValues.Seven);
			var five = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Eight);

			var result = new List<PokerCard>();
			result.Add(one);
			result.Add(two);
			result.Add(three);
			result.Add(four);
			result.Add(five);

			return result;
		}



		public static List<PokerCard> LoadFourOfAKind()
		{
			var one = NewCardBySuitByValue(CardSuits.Clubs, CardValues.King);
			var two = NewCardBySuitByValue(CardSuits.Hearts, CardValues.King);
			var three = NewCardBySuitByValue(CardSuits.Diamonds, CardValues.King);
			var four = NewCardBySuitByValue(CardSuits.Spades, CardValues.King);
			var five = NewCardBySuitByValue(CardSuits.Hearts, CardValues.Eight);

			var result = new List<PokerCard>();
			result.Add(one);
			result.Add(two);
			result.Add(three);
			result.Add(four);
			result.Add(five);

			return result;
		}
		#endregion


	}
}
