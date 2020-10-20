using System.Web.Mvc;
using PersonalGram.Models.Context;
using PersonalGram.Models.PhotoModels;

namespace PersonalGram.Controllers
{
    public class PhotoController : Controller
    {
        PhotoContext _photoContext = new PhotoContext();

        // GET
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photo photo)
        {
            //Photo photo = new Photo();
            //photo.Content = data;
            _photoContext.Photos.Add(photo);
            return RedirectToAction("Index");
        }
    }
}