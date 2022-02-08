using Puzzles.Bl.Enumerations;
using Puzzles.Bl.PokerHandEvaluator.Models;

namespace Puzzles.Bl.Extensions
{
	public static class PokerHandExtensions
	{
		public static bool IsRoyalFlush(this List<PokerCard> cards)
		{
			var orderedcards = cards.OrderBy(x => x.CardValue).ToList();


			return false;
		}


		public static bool IsStraightFlush(this List<PokerCard> cards)
		{

			return false;
		}

		public static bool IsFourOfAKind(this List<PokerCard> cards)
		{
			var values = cards.Select(x => x.CardValue).OrderBy(x => x).ToList();


			// we dont care about suit. loop through the values and see if the count of any is TWO. only two
			foreach (var val in values)
			{

				return _DoesThisCardExistInTheHandXTimes(val, values, 4);
				//var count = values.Where(x => x == val).Count();

				//if (count == 4)
				//{
				//	return true;
				//}
			}
			return false;
		}


		public static bool IsFullHouse(this List<PokerCard> cards)
		{

			return false;
		}

		public static bool IsFlush(this List<PokerCard> cards)
		{

			return false;
		}

		public static bool IsStraight(this List<PokerCard> cards)
		{
			var values = cards.Select(x => (int)x.CardValue).OrderBy(x => x).ToList();

			var sequential = values.IsListOfIntsInSequentialOrder();

			if (sequential)
			{
				return true;
			}

			return false;
		}



		public static bool IsThreeOfAKind(this List<PokerCard> cards)
		{
			var values = cards.Select(x => x.CardValue).OrderBy(x => x).ToList();


			// we dont care about suit. loop through the values and see if the count of any is TWO. only two
			foreach (var val in values)
			{
				return _DoesThisCardExistInTheHandXTimes(val, values, 3);
				//	var count = values.Where(x => x == val).Count();

				//	if (count == 3)
				//	{
				//		return true;
				//	}
			}
			return false;
		}
		public static bool IsTwoPair(this List<PokerCard> cards)
		{
			var values = cards.Select(x => x.CardValue).OrderBy(x => x).ToList();

			var pairlist = new List<CardValues>();



			foreach (var val in values)
			{
				var exists = _DoesThisCardExistInTheHandXTimes(val, values, 2);

				if (exists)
				{
					pairlist.Add(val);
				}

			}


			var distinctlist = pairlist.Distinct().ToList();

			if (distinctlist.Count() == 2)
			{
				return true;
			}

			return false;
		}

		public static bool IsPair(this List<PokerCard> cards)
		{
			var values = cards.Select(x => x.CardValue).OrderBy(x => x).ToList();


			// we dont care about suit. loop through the values and see if the count of any is TWO. only two
			foreach (var val in values)
			{
				var exists = _DoesThisCardExistInTheHandXTimes(val, values, 2);

				if (exists)
				{
					return true;
				}


			}


			return false;
		}



		private static bool _DoesThisCardExistInTheHandXTimes(CardValues value, List<CardValues> cards, int listcount)
		{
			var certainCardCount = cards.Where(x => x == value).Count();

			if (certainCardCount == listcount)
			{
				return true;
			}

			return false;
		}



	}
}
