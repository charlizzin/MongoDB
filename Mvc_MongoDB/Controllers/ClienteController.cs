using System.Web.Mvc;
using Mvc_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Mvc_MongoDB.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MongoDBAula Context = new MongoDBAula();
        // GET: Cliente
        public ActionResult Index()
        {
            var Clientes = Context.Clientes.FindAll().SetSortOrder(SortBy<Cliente>.Ascending(x => x.Nome));
            return View(Clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente _cliente)
        {
            if (ModelState.IsValid)
            {
                Context.Clientes.Insert(_cliente);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            var cliente = Context.Clientes.FindOneById(new ObjectId(id));
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente _cliente)
        {
            if (ModelState.IsValid)
            {
                Context.Clientes.Save(_cliente);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(string id)
        {
            var del = Context.Clientes.FindOneById(new ObjectId(id));
            return View(del);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var del = Context.Clientes.Remove(Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }
    }
}
