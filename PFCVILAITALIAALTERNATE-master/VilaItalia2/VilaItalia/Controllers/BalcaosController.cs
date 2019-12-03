using PagedList;
using Rotativa;
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
    public class BalcaosController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();


      /*  public ActionResult FinalizarPedido()
        {

            ViewBag.balcao = new SelectList(db.Balcaos, "BalcaoId", "Cliente.Nome");
            return View();
        }

        //POST: Balcaos/FinalizarPedido
        [HttpPost]
        public ActionResult FinalizarPedido(int balcao)
        {
            Balcao balcon = db.Balcaos.Find(balcao);
            TempData["balcao"] = balcon;
            //ViewBag.balcao = new SelectList(db.Balcaos, "BalcaoId", "Cliente.Nome");
            return RedirectToAction("NotaFiscal");
        }*/
        //GET: NotaFiscal
        public ActionResult NotaFiscal(int? Id)
        {
            Balcao balc = db.Balcaos.Find(Id);
            Cliente cliente = db.Clientes.Find(balc.ClienteId);
            ViewBag.NomeCliente = cliente.Nome;
            ViewBag.CPFCliente = cliente.CPF;
            ViewBag.Valortotal = balc.ValorTotal;
            ViewBag.ValorAtual = balc.ValorAtual;
            TempData["balcao"] = balc;
            return View();
        }
        //POST: NotaFiscal
        [HttpPost]
        public ActionResult NotaFiscal(int BalcaoId)
        {

            Balcao balc = null;
                //Balcao balc = db.Balcaos.Find(id);
                 if (TempData["balcao"] != null)
                  {
                    balc = TempData["balcao"] as Balcao;
                }

                /*  List<Balcao> balcaos = new List<Balcao>();
                  balcaos.Add(balc);
                  balcaos.OrderBy(b => b.BalcaoId);*/

                /*var pdf = new ViewAsPdf
                 {
                     ViewName = "NotaFiscal",
                     IsGrayScale = true,
                     PageSize = Rotativa.Options.Size.A4,
                     Model = balcaos.ToPagedList(1, balcaos.Count())
                 };
                 return pdf; */

                return RedirectToAction("Create" + "/" + balc.BalcaoId, "Pagamentos");
            

        }
            
        


        // GET: Balcaos
        public ActionResult Index()
        {
            //double valor = (double)TempData["Valor"];
           // ViewBag.Valor = valor;
            var balcaos = db.Balcaos.Include(b => b.Cliente);
            return View(balcaos.ToList());
        }

        // GET: Balcaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balcao balcao = db.Balcaos.Find(id);
            if (balcao == null)
            {
                return HttpNotFound();
            }
            return View(balcao);
        }
        //GET: VIEW BEGINCOLLECITON
       /* public ActionResult AdicionaReceita()
        {
            var receita = new Receita();
            {
                //receita.ReceitaId
            };

            return PartialView("_Receita", receita);
        }*/


        // GET: Balcaos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.ProdutosId = new SelectList(db.Produtoes,"ProdutoId","Nome");
            ViewBag.ReceitasId = new SelectList(db.Receitas,"ReceitaId","Nome");
            return View();
        }

        // POST: Balcaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BalcaoId,ClienteId")] Balcao balcao,string Tamanho1,List<int>ProdutosId,List<int>ReceitasId,Cliente pesquisado)
        {
            //int cont = 0;
            Pizza pizza = new Pizza();


            pizza.Tamanho = Tamanho1;
            
            db.Pizzas.Add(pizza);
            db.SaveChanges();
          
        
             foreach (int id in ReceitasId)
             {
                 //cont += 1;
                 Receita receita= db.Receitas.Find(id);
                 balcao.ValorTotal += receita.PrecoFixo;
                 pizza.Sabores.Add(receita); 

             }

            if (ProdutosId != null)
            {
                foreach (int id in ProdutosId)
                {
                    Produto produto = db.Produtoes.Find(id);
                    balcao.ValorTotal += produto.PrecoVenda;
                    balcao.Produtos.Add(produto);
                }
            }
            else
            {
                balcao.Produtos = null;
            }
            balcao.ValorAtual = balcao.ValorTotal;
                //db.Pizzas.Add(pizza);
                db.Entry(pizza).State = EntityState.Modified;
                db.Balcaos.Add(balcao);
                db.SaveChanges();
                return RedirectToAction("Create","Pagamentos");
            

       
            /*   if (ModelState.IsValid)
               {
                   db.Balcaos.Add(balcao);
                   db.SaveChanges();
                   TempData["Valor"] = valor;
                   return RedirectToAction("Index");
               } */

        }

        // GET: Balcaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balcao balcao = db.Balcaos.Find(id);
            if (balcao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", balcao.ClienteId);
            return View(balcao);
        }

        // POST: Balcaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BalcaoId,ClienteId")] Balcao balcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", balcao.ClienteId);
            return View(balcao);
        }

        // GET: Balcaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balcao balcao = db.Balcaos.Find(id);
            if (balcao == null)
            {
                return HttpNotFound();
            }
            return View(balcao);
        }

        // POST: Balcaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Balcao balcao = db.Balcaos.Find(id);
            db.Balcaos.Remove(balcao);
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

        public ActionResult TelaInicial()
        {
            return View();
        }
    }
}
