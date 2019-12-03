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
    public class MesasController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Mesas
        public ActionResult Index()
        {
            var mesas = db.Mesas.Include(m => m.Cliente);
            return View(mesas.ToList());
        }

        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesas.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.ProdutosId = new SelectList(db.Produtoes, "ProdutoId", "Nome");
            ViewBag.ReceitasId = new SelectList(db.Receitas, "ReceitaId", "Nome");
            ViewBag.MesaAdicionadaId = new SelectList(db.MesaAdicionadas.Where(x=> x.Disponibilidade == true), "MesaAdicionadaId", "Nome");
            
            return View();
        }

        // POST: Mesas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MesaId,ClienteId,MesaAdicionadaId")] Mesa mesa,string Tamanho1, List<int> ProdutosId, List<int> ReceitasId)
        {
            Pizza pizza = new Pizza();


            pizza.Tamanho = Tamanho1;

            db.Pizzas.Add(pizza);
            db.SaveChanges();
            MesaAdicionada mesinha = db.MesaAdicionadas.Find(mesa.MesaAdicionadaId);
            mesinha.Disponibilidade = false;
            db.Entry(mesinha).State = EntityState.Modified;

            foreach (int id in ReceitasId)
            {
                //cont += 1;
                Receita receita = db.Receitas.Find(id);
                mesa.ValorTotal += receita.PrecoFixo;
                pizza.Sabores.Add(receita);

            }

            if (ProdutosId != null)
            {
                foreach (int id in ProdutosId)
                {
                    Produto produto = db.Produtoes.Find(id);
                    mesa.ValorTotal += produto.PrecoVenda;
                    mesa.Produtos.Add(produto);
                }
            }
            else
            {
                mesa.Produtos = null;
            }
            mesa.ValorAtual = mesa.ValorTotal;
         
            //db.Pizzas.Add(pizza);
            db.Entry(pizza).State = EntityState.Modified;
            db.Mesas.Add(mesa);
            db.SaveChanges();
            return RedirectToAction("TelaInicial", "Balcaos");
        }
    
    

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesas.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", mesa.ClienteId);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MesaId,ClienteId")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", mesa.ClienteId);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesa mesa = db.Mesas.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesa mesa = db.Mesas.Find(id);
            db.Mesas.Remove(mesa);
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
