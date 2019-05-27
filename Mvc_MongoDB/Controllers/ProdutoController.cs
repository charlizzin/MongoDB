using System.Web.Mvc;
using Mvc_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Mvc_MongoDB.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly MongoDBAula Context = new MongoDBAula();
        // GET: Produto
        public ActionResult Index()
        {
            var produtos = Context.Produtos.FindAll().SetSortOrder(SortBy<Produto>.Ascending(x => x.Descricao));
            return View(produtos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto _produto)
        {
            if (ModelState.IsValid)
            {
                Context.Produtos.Insert(_produto);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(string id)
        {
            var produto = Context.Produtos.FindOneById(new ObjectId(id));
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto _produto)
        {
            if (ModelState.IsValid)
            {
                Context.Produtos.Save(_produto);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(string id)
        {
            var del = Context.Produtos.FindOneById(new ObjectId(id));
            return View(del);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var del = Context.Produtos.Remove(Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }
    }
}
