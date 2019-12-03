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
    public class DeliveriesController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Deliveries
        public ActionResult Index()
        {
            var deliveries = db.Deliveries.Include(d => d.Cliente).Include(d => d.Motoboy);
            return View(deliveries.ToList());
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.MotoboyId = new SelectList(db.Motoboys, "MotoboyId", "Nome");
            ViewBag.ProdutosId = new SelectList(db.Produtoes, "ProdutoId", "Nome");
            ViewBag.ReceitasId = new SelectList(db.Receitas, "ReceitaId", "Nome");
            return View();
        }

        // POST: Deliveries/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryId,ClienteId,MotoboyId")] Delivery delivery, Balcao balcao, string Tamanho1, List<int> ProdutosId, List<int> ReceitasId)
        {
            Pizza pizza = new Pizza();


            pizza.Tamanho = Tamanho1;

            db.Pizzas.Add(pizza);
            db.SaveChanges();


            foreach (int id in ReceitasId)
            {
                //cont += 1;
                Receita receita = db.Receitas.Find(id);
                delivery.ValorTotal += receita.PrecoFixo;
                pizza.Sabores.Add(receita);

            }

            if (ProdutosId != null)
            {
                foreach (int id in ProdutosId)
                {
                    Produto produto = db.Produtoes.Find(id);
                    delivery.ValorTotal += produto.PrecoVenda;
                    delivery.Produtos.Add(produto);
                }
            }
            else
            {
                delivery.Produtos = null;
            }
            delivery.ValorAtual = delivery.ValorTotal;
            //db.Pizzas.Add(pizza);
            db.Entry(pizza).State = EntityState.Modified;
            db.Deliveries.Add(delivery);
            db.SaveChanges();
            return RedirectToAction("Create", "Pagamentos");



     

        }
   

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", delivery.ClienteId);
            ViewBag.MotoboyId = new SelectList(db.Motoboys, "MotoboyId", "Nome", delivery.MotoboyId);
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryId,ClienteId,MotoboyId")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", delivery.ClienteId);
            ViewBag.MotoboyId = new SelectList(db.Motoboys, "MotoboyId", "Nome", delivery.MotoboyId);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            db.Deliveries.Remove(delivery);
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
