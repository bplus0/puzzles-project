using Microsoft.AspNetCore.Mvc;
using Puzzles.Bl.Exceptions;
using Puzzles.Bl.PokerHandEvaluator;
using Puzzles.Bl.PokerHandEvaluator.Models;
using Puzzles.Models;

namespace Puzzles.Controllers
{
  public class PokerHandEvaluatorController : Controller
  {

    private readonly ILogger<HomeController> _logger;
    private readonly IPokerHandEvaluatorBl _bl;
    public PokerHandEvaluatorController(ILogger<HomeController> logger, IPokerHandEvaluatorBl bl)
    {
      _logger = logger;
      _bl = bl;
    }


    [HttpGet]
    [Route("projects/pokerhandevaluator/home")]
    public ActionResult PokerHandEvaluatorHome()
    {

      var msg = "";
      try
      {

        var model = new PokerHandEvaluatorHomeModel();
        return View("Index_PokerHandEvaluator", model);
      }
      catch (PuzzlesApplicationException ax)
      {
        msg = ax.Message;
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //_log.LogError(" - ", ex.Message);
      }
      return View("Error", new StringModel(msg));

    }



  }
}
