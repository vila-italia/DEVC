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
    public class PizzasController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Pizzas
        public ActionResult Index()
        {
            var pizzas = db.Pizzas.Include(p => p.Balcao).Include(p => p.Delivery).Include(p => p.Mesa);
            return View(pizzas.ToList());
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId");
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId");
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId");
            return View();
        }


        // POST: Pizzas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PizzaId,Tamanho,BalcaoId,MesaId,DeliveryId")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pizza.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pizza.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pizza.MesaId);
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pizza.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pizza.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pizza.MesaId);
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PizzaId,Tamanho,BalcaoId,MesaId,DeliveryId")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BalcaoId = new SelectList(db.Balcaos, "BalcaoId", "BalcaoId", pizza.BalcaoId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "DeliveryId", "DeliveryId", pizza.DeliveryId);
            ViewBag.MesaId = new SelectList(db.Mesas, "MesaId", "MesaId", pizza.MesaId);
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
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
