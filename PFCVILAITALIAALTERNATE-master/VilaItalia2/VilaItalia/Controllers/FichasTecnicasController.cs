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
    public class FichasTecnicasController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: FichasTecnicas
        public ActionResult Index()
        {
            return View(db.FichaTecnicas.ToList());
        }

        // GET: FichasTecnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaTecnica fichaTecnica = db.FichaTecnicas.Find(id);

            

            
            // Insumo_Ficha insumo_Ficha = db.Insumo_Ficha.Find(f);
            if (fichaTecnica == null)
            {
                return HttpNotFound();
            }
            return View(fichaTecnica);
        }

        // GET: FichasTecnicas/Create
        public ActionResult Create()
        {
            ViewBag.InsumoId = new SelectList(db.Insumoes, "InsumoId", "InsumoNome");
            
            return View();
        }

        // POST: FichasTecnicas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FichaTecnicaId,FichaNome,PrecoSugerido,PrecoSabor")] FichaTecnica fichaTecnica, IList<int> InsumoId)
        {
            if (ModelState.IsValid)
            {
                
                foreach (var idInsumo in InsumoId)
                {
                    Insumo_Ficha insumo_Ficha = new Insumo_Ficha();
                    insumo_Ficha.FichaTecnicaId = fichaTecnica.FichaTecnicaId;
                    insumo_Ficha.InsumoId = idInsumo;
                    db.Insumo_Ficha.Add(insumo_Ficha);
                }
                db.FichaTecnicas.Add(fichaTecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fichaTecnica);
        }

        // GET: FichasTecnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaTecnica fichaTecnica = db.FichaTecnicas.Find(id);
            if (fichaTecnica == null)
            {
                return HttpNotFound();
            }
            return View(fichaTecnica);
        }

        // POST: FichasTecnicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FichaTecnicaId,FichaNome,PrecoSugerido,PrecoSabor")] FichaTecnica fichaTecnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaTecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fichaTecnica);
        }

        // GET: FichasTecnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaTecnica fichaTecnica = db.FichaTecnicas.Find(id);
            if (fichaTecnica == null)
            {
                return HttpNotFound();
            }
            return View(fichaTecnica);
        }

        // POST: FichasTecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FichaTecnica fichaTecnica = db.FichaTecnicas.Find(id);
            db.FichaTecnicas.Remove(fichaTecnica);
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
