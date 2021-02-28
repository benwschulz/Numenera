using LibraryData.DbData;
using System.Web.Mvc;

namespace Numenera
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (libraryEntities library = new libraryEntities())
            {
                return View();
            }
        }

        public ActionResult CharacterScreen(int id)
        {
            return RedirectToAction("Index", "Character/Characters", new { id = id });
        }
    }
}