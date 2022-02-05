namespace Puzzles.Exceptions
{
  public class AppException : Exception
  {
    public AppException(string exception)
    {
      AppExceptionMessage = exception;
    }

    public string AppExceptionMessage { get; set; }
  }
}