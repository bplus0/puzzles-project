using Microsoft.AspNetCore.Mvc;
using Puzzles.Bl.Exceptions;
using Puzzles.Bl.NumberToString.Models;
using Puzzles.Bl.PalindromeChecker;
using Puzzles.Bl.PalindromeChecker.Models;
using Puzzles.Models;

namespace Puzzles.Controllers
{
  public class PalindromeCheckerController : Controller
  {
    //private readonly ILogger<HomeController> _logger;
    private readonly IPalindromeCheckerBl _bl;
    public PalindromeCheckerController(IPalindromeCheckerBl bl)
    {
      //_logger = logger;
      _bl = bl;
    }




    [HttpGet]
    [Route("projects/palindromechecker/home")]
    public ActionResult PalindromeCheckerPage()
    {

      var msg = "";
      try
      {

        var model = new NumberToStringHomeModel();
        return View("Index_PalindromeChecker", model);
      }
      catch (PuzzlesApplicationException ax)
      {
        msg = ax.Message;
      }
      catch (Exception ex)
      {
        msg = "An error has occured";
        //_log.LogError(" - ", ex.Message);
      }
      return View("Error", new StringModel(msg));

    }

    [HttpPost]
    [Route("projects/palindromechecker/_submit")]
    public async Task<ActionResult> SubmitPalindromeCheck(PalindromeCheckerModel model)
    {

      try
      {
        var submitted = await _bl.SubmitCheckPalindromeCheckerModelAsync(model).ConfigureAwait(false);
        submitted.Saved = true;
        return PartialView("_PalindromeCheckerForm", submitted);
      }
      catch (PuzzlesApplicationException ax)
      {
        ModelState.AddModelError("", ax.Message);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //_log.LogWarning(ex.Message);
      }
      return PartialView("_PalindromeCheckerForm", model);
    }




  }
}
