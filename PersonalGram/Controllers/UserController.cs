using System.Web.Mvc;
using PersonalGram.Models;
using PersonalGram.Models.Context;

namespace PersonalGram.Controllers
{
    public class UserController : Controller
    {
        UserContext _userContext = new UserContext();

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return View();
        }
    }
}