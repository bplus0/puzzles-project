using Puzzles.Bl.Exceptions;
using Puzzles.Bl.Extensions;
using Puzzles.Bl.PalindromeChecker.Models;

namespace Puzzles.Bl.PalindromeChecker
{
	public class PalindromeCheckerBl : IPalindromeCheckerBl
	{
		public PalindromeCheckerBl()
		{

		}

		public async Task<PalindromeCheckerModel> SubmitCheckPalindromeCheckerModelAsync(PalindromeCheckerModel model)
		{
			if (model.NumberToCheck < -1000000000)
			{
				throw new PuzzlesApplicationException($"Please enter a positive number greater than zero");
			}

			if (model.NumberToCheck > 1000000000)
			{
				throw new PuzzlesApplicationException($"This is a very large number. For the sake of this exercise. Let's keep it less than a trillion");

			}

			//first guess
			if (model.PreviousGuesses.IsNullOrWhiteSpace())
			{
				model.PreviousGuesses = $"{model.NumberToCheck}, ";
			}
			else
			{
				model.PreviousGuesses = $"{model.PreviousGuesses} {model.NumberToCheck}, ";
			}



			if (model.NumberToCheck < 0)
			{
				var positivenumber = Math.Abs(model.NumberToCheck);
				model.NumberToCheck = positivenumber;
			}


			var numbertocheck = model.NumberToCheck;
			var reversednumber = model.NumberToCheck.ReverseInt();




			if (numbertocheck.Equals(reversednumber))
			{
				model.ReturnMessage = $"Boom. We have a palindrome.";
				model.PalindromeFound = true;
			}
			else
			{
				model.ReturnMessage = "No palindrome. Try again";
				model.PalindromeFound = false;
			}




			return model;
		}
	}
}
