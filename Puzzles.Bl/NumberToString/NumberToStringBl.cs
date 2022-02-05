using Puzzles.Bl.Exceptions;
using Puzzles.Bl.NumberToString.Models;

namespace Puzzles.Bl.NumberToString
{
  public class NumberToStringBl : INumberToStringBl
  {
    public NumberToStringBl()
    {

    }


    #region convert number to string
    public string ReturnHello()
    {
      return "Hello";
    }

    /// <summary>
    /// I'm not hitting any DB. just showing that async is the way to go :D
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<NumberToStringConvertModel> SubmitNumberToStringConvertModel(NumberToStringConvertModel model)
    {

      if (model.Input <= 0)
      {
        throw new PuzzlesApplicationException($"We can throw exceptions. I would prefer if you kept these to positive numbers. GREATER than zero");
      }

      if (model.Input > 1000000000)
      {
        throw new PuzzlesApplicationException($"This is a very large number. For the sake of this exercise. Let's keep it less than a trillion");

      }


      model.Result = DoubleToWords((double)model.Input);

      return model;
    }




    /// <summary>
    /// Found this on C# corner. needed to tweak
    /// </summary>
    /// <param name="doubleNumber"></param>
    /// <returns></returns>
    public string DoubleToWords(double doubleNumber)
    {
      int beforeFloatingPoint = (int)Math.Floor(doubleNumber);

      var beforedecimal = $"{NumberToWords(beforeFloatingPoint)}";

      var first2DecimalPlaces = (int)(((decimal)doubleNumber % 1) * 100);

      //not an even number
      if ((int)((doubleNumber - beforeFloatingPoint) * 100) > 0)
      {

        return $"{beforedecimal} and {first2DecimalPlaces}/100 dollars";
      }
      else
      {
        return $"{beforedecimal} dollars";
      }
    }

    private string NumberToWords(int number)
    {
      if (number == 0)
        return "zero";

      if (number < 0)
        return "minus " + NumberToWords(Math.Abs(number));

      var words = "";




      if (number / 1000000000 > 0)
      {
        words += NumberToWords(number / 1000000000) + " billion ";
        number %= 1000000000;
      }

      if (number / 1000000 > 0)
      {
        words += NumberToWords(number / 1000000) + " million ";
        number %= 1000000;
      }

      if (number / 1000 > 0)
      {
        words += NumberToWords(number / 1000) + " thousand ";
        number %= 1000;
      }

      if (number / 100 > 0)
      {
        words += NumberToWords(number / 100) + " hundred ";
        number %= 100;
      }

      words = SmallNumberToWord(number, words);

      return words;
    }

    private string SmallNumberToWord(int number, string words)
    {
      if (number <= 0) return words;
      if (words != "")
        words += " ";

      var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
      var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

      if (number < 20)
        words += unitsMap[number];
      else
      {
        words += tensMap[number / 10];
        if ((number % 10) > 0)
          words += " " + unitsMap[number % 10];
      }
      return words;
    }

    #endregion

  }
}
