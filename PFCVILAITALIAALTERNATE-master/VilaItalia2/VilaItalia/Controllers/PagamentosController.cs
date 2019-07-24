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
    public class PagamentosController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentoes = db.Pagamentoes.Include(p => p.Balcao).Include(p => p.Delivery).Include(p => p.Mesa);
            return View(pagamentoes.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId");
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId");
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagamentoId,FormaPagamento,BalcaoId,MesaId,DeliveryId")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                if (pagamento.FormaPagamento == FormaPagamento.Dinheiro)
                {
                    db.Pagamentoes.Add(pagamento);
                    db.SaveChanges();
                    return RedirectToAction("Create" + "/" + pagamento.PagamentoId, "PagamentoDinheiros");
                }
                else if (pagamento.FormaPagamento == FormaPagamento.CartaoDebito)
                {
                    db.Pagamentoes.Add(pagamento);
                    db.SaveChanges();
                    return RedirectToAction("Create" + "/" + pagamento.PagamentoId, "PagamentoCartaoDebitos");
                }
                db.Pagamentoes.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pagamento.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pagamento.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pagamento.MesaId);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pagamento.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pagamento.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pagamento.MesaId);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagamentoId,FormaPagamento,BalcaoId,MesaId,DeliveryId")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pagamento.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pagamento.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pagamento.MesaId);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamentoes.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamento pagamento = db.Pagamentoes.Find(id);
            db.Pagamentoes.Remove(pagamento);
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
