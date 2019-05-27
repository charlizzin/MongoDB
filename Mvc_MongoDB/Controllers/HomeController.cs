using System.Web.Mvc;
using Mvc_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Mvc_MongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly PaisDB Context = new PaisDB();

        public ActionResult Index()
        {
            var Paises = Context.Paises.FindAll().SetSortOrder(SortBy<Pais>.Ascending(r => r.PaisCodigo));
            return View(Paises);
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Pais _pais)
        {
            if (ModelState.IsValid)
            {
                Context.Paises.Insert(_pais);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            var pais = Context.Paises.FindOneById(new ObjectId(Id));
            return View(pais);
        }

        [HttpPost]
        public ActionResult Edit(Pais _pais)
        {
            if (ModelState.IsValid)
            {
                Context.Paises.Save(_pais);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var del = Context.Paises.FindOneById(new ObjectId(Id));
            return View(del);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var del = Context.Paises.Remove(Query.EQ("_id", new ObjectId(Id)));
            return RedirectToAction("Index");
        }
    }
}