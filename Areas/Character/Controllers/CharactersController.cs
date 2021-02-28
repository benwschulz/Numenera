using LibraryData;
using LibraryData.DbData;
using System.Web.Mvc;

namespace Numenera.Areas.Character
{
    public class CharactersController : Controller
    {
        // GET: Character/Characters
        public ActionResult Index(int id)
        {
            using (libraryEntities db = new libraryEntities())
            {
                var model = new CharacterModel(id);
                return View(model);
            }
        }
    }
}