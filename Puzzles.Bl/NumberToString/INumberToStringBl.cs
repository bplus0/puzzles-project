using Puzzles.Bl.NumberToString.Models;

namespace Puzzles.Bl.NumberToString
{
    public interface INumberToStringBl
    {

        #region Convert Number To String
        string ReturnHello();
        Task<NumberToStringCalculateModel> SubmitNumberToStringConvertModel(NumberToStringCalculateModel model);

        #endregion
    }
}
