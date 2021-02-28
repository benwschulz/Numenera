using System.Web.Mvc;

namespace Numenera.Areas.Character
{
    public class CharactersController : Controller
    {
        // GET: Character/Characters
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}