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
    public class MesaAdicionadaController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: MesaAdicionada
        public ActionResult Index()
        {
            return View(db.MesaAdicionadas.ToList());
        }

        // GET: MesaAdicionada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesaAdicionada mesaAdicionada = db.MesaAdicionadas.Find(id);
            if (mesaAdicionada == null)
            {
                return HttpNotFound();
            }
            return View(mesaAdicionada);
        }

        // GET: MesaAdicionada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MesaAdicionada/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MesaAdicionadaId,Nome,Disponibilidade")] MesaAdicionada mesaAdicionada)
        {
            if (ModelState.IsValid)
            {
                db.MesaAdicionadas.Add(mesaAdicionada);
                db.SaveChanges();
                return RedirectToAction("TelaInicial","Balcaos");
            }

            return View(mesaAdicionada);
        }

        // GET: MesaAdicionada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesaAdicionada mesaAdicionada = db.MesaAdicionadas.Find(id);
            if (mesaAdicionada == null)
            {
                return HttpNotFound();
            }
            return View(mesaAdicionada);
        }

        // POST: MesaAdicionada/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MesaAdicionadaId,Nome,Disponibilidade")] MesaAdicionada mesaAdicionada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesaAdicionada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesaAdicionada);
        }

        // GET: MesaAdicionada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MesaAdicionada mesaAdicionada = db.MesaAdicionadas.Find(id);
            if (mesaAdicionada == null)
            {
                return HttpNotFound();
            }
            return View(mesaAdicionada);
        }

        // POST: MesaAdicionada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MesaAdicionada mesaAdicionada = db.MesaAdicionadas.Find(id);
            db.MesaAdicionadas.Remove(mesaAdicionada);
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
