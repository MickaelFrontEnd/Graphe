using System.Web.Mvc;

namespace Graphe.Affichage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Graphe"] = Session["Graphe"] == null ? new GrapheO<string>() : Session["Graphe"];
            return View("~/Views/Graphe/Graphe.cshtml");
        }

        public JsonResult AjouterNoeud(string nomNoeud)
        {
            ((GrapheO<string>)Session["Graphe"]).AjouterNoeud(nomNoeud);
            return Json(new { status = "created" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModifierNoeud(string ancienNoeud, string nouveauNoeud)
        {
            ((GrapheO<string>)Session["Graphe"]).ModifierNoeud(ancienNoeud, nouveauNoeud);
            return Json(new { status = "modified" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SupprimerNoeud(string noeud)
        {
            ((GrapheO<string>)Session["Graphe"]).SupprimerNoeud(noeud);
            return Json(new { status = "deleted" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AjouterArc(string noeudA,string noeudB,double capacite,double cout)
        {
            ((GrapheO<string>)Session["Graphe"]).AjouterArc(noeudA,noeudB,capacite,cout);
            return Json(new { status = "created" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMatriceCout()
        {
            return PartialView("~/Views/Graphe/_MatriceCout.cshtml");
        }

        public ActionResult GetMatriceAdjacence()
        {
            return PartialView("~/Views/Graphe/_MatriceAdjacence.cshtml");
        }
    }
}