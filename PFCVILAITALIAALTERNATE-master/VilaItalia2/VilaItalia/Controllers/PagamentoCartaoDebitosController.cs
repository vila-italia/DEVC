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
    public class PagamentoCartaoDebitosController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: PagamentoCartaoDebitos
        public ActionResult Index()
        {
            return View(db.PagamentoCartaoDebitoes.ToList());
        }

        // GET: PagamentoCartaoDebitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoDebito pagamentoCartaoDebito = db.PagamentoCartaoDebitoes.Find(id);
            if (pagamentoCartaoDebito == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoCartaoDebito);
        }

        // GET: PagamentoCartaoDebitos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagamentoCartaoDebitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagamentoCartaoDebitoId,Valor")] PagamentoCartaoDebito pagamentoCartaoDebito)
        {
            if (ModelState.IsValid)
            {
                db.PagamentoCartaoDebitoes.Add(pagamentoCartaoDebito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagamentoCartaoDebito);
        }

        // GET: PagamentoCartaoDebitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoDebito pagamentoCartaoDebito = db.PagamentoCartaoDebitoes.Find(id);
            if (pagamentoCartaoDebito == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoCartaoDebito);
        }

        // POST: PagamentoCartaoDebitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagamentoCartaoDebitoId,Valor")] PagamentoCartaoDebito pagamentoCartaoDebito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentoCartaoDebito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagamentoCartaoDebito);
        }

        // GET: PagamentoCartaoDebitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoDebito pagamentoCartaoDebito = db.PagamentoCartaoDebitoes.Find(id);
            if (pagamentoCartaoDebito == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoCartaoDebito);
        }

        // POST: PagamentoCartaoDebitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagamentoCartaoDebito pagamentoCartaoDebito = db.PagamentoCartaoDebitoes.Find(id);
            db.PagamentoCartaoDebitoes.Remove(pagamentoCartaoDebito);
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
