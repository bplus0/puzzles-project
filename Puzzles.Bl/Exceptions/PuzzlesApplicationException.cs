namespace Puzzles.Bl.Exceptions
{
  public class PuzzlesApplicationException : Exception
  {
    public PuzzlesApplicationException(string exception)
    {
      Message = exception;
    }

    public string Message { get; set; }
  }
}