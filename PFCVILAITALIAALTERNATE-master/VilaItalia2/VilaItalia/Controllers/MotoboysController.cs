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
    public class MotoboysController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Motoboys
        public ActionResult Index()
        {
            return View(db.Motoboys.ToList());
        }

        // GET: Motoboys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motoboy motoboy = db.Motoboys.Find(id);
            if (motoboy == null)
            {
                return HttpNotFound();
            }
            return View(motoboy);
        }

        // GET: Motoboys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motoboys/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotoboyId,Nome,Telefone,Celular,CPF,Dia_Aniversario,Mes_Aniversario,Ano_Aniversario,Email,CEP,Complemento,Bairro,Rua,Cidade,Referencia,Observacao,numerCnh")] Motoboy motoboy)
        {
            if (ModelState.IsValid)
            {
                db.Motoboys.Add(motoboy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motoboy);
        }

        // GET: Motoboys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motoboy motoboy = db.Motoboys.Find(id);
            if (motoboy == null)
            {
                return HttpNotFound();
            }
            return View(motoboy);
        }

        // POST: Motoboys/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotoboyId,Nome,Telefone,Celular,CPF,Dia_Aniversario,Mes_Aniversario,Ano_Aniversario,Email,CEP,Complemento,Bairro,Rua,Cidade,Referencia,Observacao,numerCnh")] Motoboy motoboy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motoboy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motoboy);
        }

        // GET: Motoboys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motoboy motoboy = db.Motoboys.Find(id);
            if (motoboy == null)
            {
                return HttpNotFound();
            }
            return View(motoboy);
        }

        // POST: Motoboys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motoboy motoboy = db.Motoboys.Find(id);
            db.Motoboys.Remove(motoboy);
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
