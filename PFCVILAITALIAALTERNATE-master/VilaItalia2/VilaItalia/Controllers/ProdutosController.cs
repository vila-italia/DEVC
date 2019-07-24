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
    public class ProdutosController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtoes = db.Produtoes.Include(p => p.Balcao).Include(p => p.Delivery).Include(p => p.Mesa);
            return View(produtoes.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId");
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId");
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId");
            return View();
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Quantidade,PrecoCompra,PrecoVenda,PrecoMedio,PercentLucro,PrecoSugerido,Aliquota,Tipo,Medida,BalcaoId,MesaId,DeliveryId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", produto.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", produto.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", produto.MesaId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", produto.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", produto.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", produto.MesaId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Quantidade,PrecoCompra,PrecoVenda,PrecoMedio,PercentLucro,PrecoSugerido,Aliquota,Tipo,Medida,BalcaoId,MesaId,DeliveryId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", produto.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", produto.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", produto.MesaId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
