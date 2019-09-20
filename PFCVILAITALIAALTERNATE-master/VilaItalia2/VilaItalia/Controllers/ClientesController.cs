using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VilaItalia.Models;
using System.Linq.Dynamic;

namespace VilaItalia.Controllers
{
    public class ClientesController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        //POST: gelist
        [HttpPost]
        public ActionResult GetList()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchvalue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Cliente> clientes = new List<Cliente>();
            clientes = db.Clientes.ToList<Cliente>();
            int totalrows = clientes.Count;
            if(!string.IsNullOrEmpty(searchvalue)){
                clientes = clientes.Where(x => x.ClienteId.ToString().Contains(searchvalue) ||x.Nome.ToLower().Contains(searchvalue.ToLower())|| x.Telefone.ToLower().Contains(searchvalue.ToString())).ToList(); 
        }
            int totalrowsafterfiltering = clientes.Count;
            clientes = clientes.OrderBy(sortColumnName + " " + sortDirection).ToList();
            clientes = clientes.Skip(start).Take(length).ToList();
            return Json(new { data = clientes, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering },JsonRequestBehavior.AllowGet );
        }
        //GET: Clientes/PesquisaArea
        public ActionResult PesquisaCliente()
        {
            return View();
        }
        //POST: Clientes/PesquisaArea
        [HttpPost]
        public ActionResult PesquisaCliente(string PesquisaCliente)
        {
            if (ModelState.IsValid)
            {

                var pesquisado = db.Clientes.Where(a => a.Celular.Contains(PesquisaCliente)).FirstOrDefault();

                if(pesquisado != null)
                {
                    return RedirectToAction("Create", "Balcaos");
                }

                return RedirectToAction("Create");
            }
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nome,Telefone,Celular,CPF,Dia_Aniversario,Mes_Aniversario,Email,CEP,Bairro,Rua,Cidade,Complemento,Referencia,Observacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Create","Balcaos");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nome,Telefone,Celular,CPF,Dia_Aniversario,Mes_Aniversario,Email,CEP,Bairro,Rua,Cidade,Complemento,Referencia,Observacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
