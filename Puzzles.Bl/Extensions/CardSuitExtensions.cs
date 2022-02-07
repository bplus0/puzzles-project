using Puzzles.Bl.Enumerations;

namespace Puzzles.Bl.Extensions
{/// <summary>
 /// Good cheat sheet: https://glyphsearch.com/?query=clubs&copy=unicode-hexadecimal
 /// https://www.htmlsymbols.xyz/unicode/U+2663
 /// </summary>
	public static class CardSuitExtensions
	{
		public static string PrettyDisplayname(CardSuits suit)
		{
			switch (suit)
			{
				case CardSuits.Clubs:
					return "&#9827;";
				case CardSuits.Hearts:
					return "&#10084;";
				case CardSuits.Diamonds:
					return "&#9670;";
				case CardSuits.Spades:
					return "&#9828;";
			}

			return "Unknown";

		}
	}
}
