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

        public JsonResult AjouterArc(string noeudA,string noeudB,double capacite,double cout)
        {
            ((Graphe<string>)Session["Graphe"]).AjouterArc(noeudA,noeudB,capacite,cout);
            return Json(new { status = "created" }, JsonRequestBehavior.AllowGet);
        }
    }
}