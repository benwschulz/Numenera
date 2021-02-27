using LibraryData.DbData;
using System.Web.Mvc;

namespace Numenera.Controllers
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
    }
}