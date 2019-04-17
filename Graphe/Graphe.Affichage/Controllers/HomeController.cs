using System.Web.Mvc;
using Graphe;

namespace Graphe.Affichage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Graphe"] = new Graphe<string>();
            return View("~/Views/Graphe/Graphe.cshtml");
        }

        public JsonResult AjouterNoeud(string nomNoeud)
        {
            ((Graphe<string>)Session["Graphe"]).AjouterNoeud(nomNoeud);
            return Json(new { status = "created" }, JsonRequestBehavior.AllowGet);
        }
    }
}