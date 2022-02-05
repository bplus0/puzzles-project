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
    public async Task<NumberToStringCalculateModel> SubmitNumberToStringConvertModel(NumberToStringCalculateModel model)
    {

      if (model.Input <= 0)
      {
        throw new PuzzlesApplicationException($"We can throw exceptions. I would prefer if you kept these to positive numbers. GREATER than zero");
      }



      return model;
    }

    #endregion

  }
}
