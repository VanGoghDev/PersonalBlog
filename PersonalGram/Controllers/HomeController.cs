using System.Web.Mvc;
using PersonalGram.Models;
using PersonalGram.Models.Context;

namespace PersonalGram.Controllers
{
    public class HomeController : Controller
    {
        UserContext _userContext = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}