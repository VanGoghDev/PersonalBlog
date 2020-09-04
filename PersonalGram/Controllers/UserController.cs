using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult Users()
        {
            var users = _userContext.Users.ToList();
            return View(users);
        }

        /// <summary>
        /// Редактирование пользователей
        /// в карточке пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult User(int? id)
        {
            if (id == null) return HttpNotFound();
            if (id < 0)
            {
                return View(new User());
            }
            var user = _userContext.Users.FirstOrDefault(p => p.Id == id);
            return View(user);
        }

        [HttpPost]
        public new ActionResult User(User user)
        {
            if (user != null)
            {
                _userContext.Users.AddOrUpdate(user);
                _userContext.SaveChanges();
            }

            return RedirectToAction("Users");
        }

        /// <summary>
        /// Добавление пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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