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
    public class SobremesasController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Sobremesas
        public ActionResult Index()
        {
            return View(db.Sobremesas.ToList());
        }

        // GET: Sobremesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sobremesa sobremesa = db.Sobremesas.Find(id);
            if (sobremesa == null)
            {
                return HttpNotFound();
            }
            return View(sobremesa);
        }

        // GET: Sobremesas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sobremesas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SobremesaId,SobremesaNome,SobremesaUltimoPreco,SobremesaPrecoMedio,SobremesaPrecoFixo,PercentLucro,PrecoSugerido,SobremesaAliquota")] Sobremesa sobremesa)
        {
            if (ModelState.IsValid)
            {
                db.Sobremesas.Add(sobremesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sobremesa);
        }

        // GET: Sobremesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sobremesa sobremesa = db.Sobremesas.Find(id);
            if (sobremesa == null)
            {
                return HttpNotFound();
            }
            return View(sobremesa);
        }

        // POST: Sobremesas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SobremesaId,SobremesaNome,SobremesaUltimoPreco,SobremesaPrecoMedio,SobremesaPrecoFixo,PercentLucro,PrecoSugerido,SobremesaAliquota")] Sobremesa sobremesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sobremesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sobremesa);
        }

        // GET: Sobremesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sobremesa sobremesa = db.Sobremesas.Find(id);
            if (sobremesa == null)
            {
                return HttpNotFound();
            }
            return View(sobremesa);
        }

        // POST: Sobremesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sobremesa sobremesa = db.Sobremesas.Find(id);
            db.Sobremesas.Remove(sobremesa);
            db.SaveChanges();
            return RedirectToAction("Index");
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
