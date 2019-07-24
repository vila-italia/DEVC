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
    public class Insumo_FichaController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Insumo_Ficha
        public ActionResult Index()
        {
            var insumo_Ficha = db.Insumo_Ficha.Include(i => i.FichaTecnica).Include(i => i.Insumo);
            return View(insumo_Ficha.ToList());
        }

        // GET: Insumo_Ficha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo_Ficha insumo_Ficha = db.Insumo_Ficha.Find(id);
            if (insumo_Ficha == null)
            {
                return HttpNotFound();
            }
            return View(insumo_Ficha);
        }

        // GET: Insumo_Ficha/Create
        public ActionResult Create()
        {
            ViewBag.FichaTecnicaId = new SelectList(db.FichaTecnicas, "FIchaTecnicaId", "FichaNome");
            ViewBag.InsumoId = new SelectList(db.Insumoes, "InsumoId", "InsumoNome");
            return View();
        }

        // POST: Insumo_Ficha/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Insumo_FichaId,InsumoId,FichaTecnicaId,PrecoInsumo,QuantidadeInsumo")] Insumo_Ficha insumo_Ficha)
        {
            if (ModelState.IsValid)
            {
                db.Insumo_Ficha.Add(insumo_Ficha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FichaTecnicaId = new SelectList(db.FichaTecnicas, "FIchaTecnicaId", "FichaNome", insumo_Ficha.FichaTecnicaId);
            ViewBag.InsumoId = new SelectList(db.Insumoes, "InsumoId", "InsumoNome", insumo_Ficha.InsumoId);
            return View(insumo_Ficha);
        }

        // GET: Insumo_Ficha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo_Ficha insumo_Ficha = db.Insumo_Ficha.Find(id);
            if (insumo_Ficha == null)
            {
                return HttpNotFound();
            }
            ViewBag.FichaTecnicaId = new SelectList(db.FichaTecnicas, "FIchaTecnicaId", "FichaNome", insumo_Ficha.FichaTecnicaId);
            ViewBag.InsumoId = new SelectList(db.Insumoes, "InsumoId", "InsumoNome", insumo_Ficha.InsumoId);
            return View(insumo_Ficha);
        }

        // POST: Insumo_Ficha/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Insumo_FichaId,InsumoId,FichaTecnicaId,PrecoInsumo,QuantidadeInsumo")] Insumo_Ficha insumo_Ficha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo_Ficha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FichaTecnicaId = new SelectList(db.FichaTecnicas, "FIchaTecnicaId", "FichaNome", insumo_Ficha.FichaTecnicaId);
            ViewBag.InsumoId = new SelectList(db.Insumoes, "InsumoId", "InsumoNome", insumo_Ficha.InsumoId);
            return View(insumo_Ficha);
        }

        // GET: Insumo_Ficha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo_Ficha insumo_Ficha = db.Insumo_Ficha.Find(id);
            if (insumo_Ficha == null)
            {
                return HttpNotFound();
            }
            return View(insumo_Ficha);
        }

        // POST: Insumo_Ficha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insumo_Ficha insumo_Ficha = db.Insumo_Ficha.Find(id);
            db.Insumo_Ficha.Remove(insumo_Ficha);
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
