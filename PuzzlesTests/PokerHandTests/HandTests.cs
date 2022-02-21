using Puzzles.Bl.Enumerations;
using Puzzles.Bl.Extensions;
using Puzzles.Bl.PokerHandEvaluator;
using Puzzles.Bl.PokerHandEvaluator.Models;
using System.Collections.Generic;
using Xunit;

namespace PuzzlesTests.PokerHandTests
{
	public class HandTests
	{

		[Fact]
		public void PokerHand_HandShouldHaveFiveCards()
		{
			//arrange
			var pokerhand = new PokerHandModel();
			var cards = new List<PokerCard>();

			//act
			cards.Add(new PokerCard(CardSuits.Clubs,CardValues.Jack));
			cards.Add(new PokerCard(CardSuits.Hearts,CardValues.Four));
			cards.Add(new PokerCard(CardSuits.Spades,CardValues.Seven));
			cards.Add(new PokerCard(CardSuits.Diamonds,CardValues.Eight));
			cards.Add(new PokerCard(CardSuits.Spades,CardValues.Ace));



			//assert
			Assert.True(cards.Count == 5);
		}





		[Fact]
		public void PokerHand_HandIsFullHouse()
		{
			//arrange
			var pokerhand = new PokerHandModel();
			var cards = new List<PokerCard>();

			//act
			cards.Add(new PokerCard(CardSuits.Clubs, CardValues.Jack));
			cards.Add(new PokerCard(CardSuits.Hearts, CardValues.Jack));
			cards.Add(new PokerCard(CardSuits.Hearts, CardValues.Four));
			cards.Add(new PokerCard(CardSuits.Diamonds, CardValues.Four));
			cards.Add(new PokerCard(CardSuits.Spades, CardValues.Four));

			//assert
			Assert.True(cards.IsFourOfAKind());
		}
	}
}