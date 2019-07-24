using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VilaItalia.Models;

namespace VilaItalia.Controllers
{
    public class IngredientesController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Ingredientes
        public ActionResult Index()
        {
            return View(db.Ingredientes.ToList());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredienteId,Nome,Quantidade,Processado,Total,UltimoPreco,PrecoMedio,Medida")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Ingredientes.Add(ingrediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredienteId,Nome,Quantidade,Processado,Total,UltimoPreco,PrecoMedio,Medida")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingrediente ingrediente = db.Ingredientes.Find(id);
            db.Ingredientes.Remove(ingrediente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Adicionar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente Ingrediente = db.Ingredientes.Find(id);
            if (Ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(Ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(int id, int quantidade, int processado, float preco)
        {
            Ingrediente Ingrediente = db.Ingredientes.Find(id);
            Ingrediente.Quantidade = Ingrediente.Quantidade + quantidade;
            Ingrediente.Processado = Ingrediente.Processado + processado;
            Ingrediente.PrecoMedio = ((preco + Ingrediente.UltimoPreco) / 2);
            Ingrediente.UltimoPreco = preco;
            if (ModelState.IsValid)
            {
                Ingrediente.Total = Ingrediente.Quantidade + Ingrediente.Processado;
                db.Entry(Ingrediente).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Ingrediente);
        }

        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente Ingrediente = db.Ingredientes.Find(id);
            if (Ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(Ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id, int quantidade, int processado)
        {
            Ingrediente Ingrediente = db.Ingredientes.Find(id);
            Ingrediente.Quantidade = Ingrediente.Quantidade - quantidade;
            Ingrediente.Processado = Ingrediente.Processado - processado;
            if (ModelState.IsValid)
            {
                db.Entry(Ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Ingrediente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
