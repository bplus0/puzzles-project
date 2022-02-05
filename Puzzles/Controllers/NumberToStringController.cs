using Microsoft.AspNetCore.Mvc;
using Puzzles.Bl.NumberToString;
using Puzzles.Bl.NumberToString.Models;
using Puzzles.Exceptions;
using Puzzles.Models;

namespace Puzzles.Controllers
{
  public class NumberToStringController : Controller
  {

    private readonly ILogger<HomeController> _logger;
    private readonly INumberToStringBl _bl;
    public NumberToStringController(ILogger<HomeController> logger, INumberToStringBl bl)
    {
      _logger = logger;
      _bl = bl;
    }


    #region Number To String Page

    [HttpGet]
    [Route("projects/numbertostring/home")]
    public ActionResult NumberToStringHome()
    {

      var msg = "";
      try
      {

        var model = new NumberToStringHomeModel();
        return View("Index_NumberToString", model);
      }
      catch (AppException ax)
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




    #region Form
    [HttpPost]
    [Route("projects/numbertostring/calculate/_submit")]
    public ActionResult SubmitNumberToString(NumberToStringCalculateModel model)
    {

      try
      {
        model.Saved = true;

        return PartialView("_NumberToStringForm", model);
      }
      catch (AppException ax)
      {
        ModelState.AddModelError("", ax.AppExceptionMessage);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //_log.LogWarning(ex.Message);
      }
      return PartialView("_ErrorMessage", new StringModel("An Error Has Occurred"));
    }

    #endregion



    #endregion



  }
}
