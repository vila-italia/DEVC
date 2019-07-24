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
    public class BebidasController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Bebidas
        public ActionResult Index()
        {
            return View(db.Bebidas.ToList());
        }

        // GET: Bebidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // GET: Bebidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bebidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BebidaId,BebidaNome,BebidaUltimoPreco,BebidaPrecoMedio,BebidaPrecoFixo,PercentLucro,PrecoSugerido,BebidaAliquota")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Bebidas.Add(bebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bebida);
        }

        // GET: Bebidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BebidaId,BebidaNome,BebidaUltimoPreco,BebidaPrecoMedio,BebidaPrecoFixo,PercentLucro,PrecoSugerido,BebidaAliquota")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bebida);
        }

        // GET: Bebidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebida bebida = db.Bebidas.Find(id);
            if (bebida == null)
            {
                return HttpNotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bebida bebida = db.Bebidas.Find(id);
            db.Bebidas.Remove(bebida);
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
