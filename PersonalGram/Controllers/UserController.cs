using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
            var users = _userContext.Users.ToList();
            return View(users);
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
            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                var user = _userContext.Users.FirstOrDefault(p => p.Id == id);
                if (user != null)
                {
                    _userContext.Users.Remove(user);
                    await _userContext.SaveChangesAsync();
                    return RedirectToAction("Users");
                }
            }

            return HttpNotFound();
        }
    }
}