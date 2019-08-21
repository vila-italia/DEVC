﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using VilaItalia.Models;

namespace VilaItalia.Controllers
{
    public class PagamentoDinheirosController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: PagamentoDinheiros
        public ActionResult Index()
        {
            return View(db.PagamentoDinheiroes.ToList());
        }

        // GET: PagamentoDinheiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Create
        public ActionResult Create(int id)
        {
            ViewBag.PagamentoId = id;
            Pagamento pagamento = db.Pagamentoes.Find(id);
            Balcao balcao = db.Balcaos.Find(pagamento.BalcaoId);
            ViewBag.ValorTotalBalcao = balcao.ValorTotal;
            ViewBag.ValorAtual = balcao.ValorAtual;
            return View();
        }

        // POST: PagamentoDinheiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagamentoDinheiroId,Troco,Valor")] PagamentoDinheiro pagamentoDinheiro,int pagamentoId, CancelEventArgs e)
        {
            if (ModelState.IsValid)
            {
                Pagamento pagamento = db.Pagamentoes.Find(pagamentoId);
                Balcao balcao = db.Balcaos.Find(pagamento.BalcaoId);
                balcao.ValorPago = (float)pagamentoDinheiro.Valor;
                
                if (balcao.ValorAtual != 0 && balcao.ValorPago>0)
                {
                    
                    balcao.ValorAtual -= (float)pagamentoDinheiro.Valor;
                   
                    db.Entry(balcao).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (balcao.ValorAtual!= 0)
                {
                 var result =  MessageBox.Show("O valor pago é menor do que o total a pagar, Continuar para a impressão de nota fiscal mesmo assim?"
                        , "Alerta",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return RedirectToAction("Create" + "/" + balcao.BalcaoId, "Pagamentos");
                    }
                    
                }

                db.PagamentoDinheiroes.Add(pagamentoDinheiro);
                db.SaveChanges();
                return RedirectToAction("NotaFiscal" + "/" + balcao.BalcaoId, "Balcaos");
            }

            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoDinheiro);
        }

        // POST: PagamentoDinheiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagamentoDinheiroId,Troco,Valor")] PagamentoDinheiro pagamentoDinheiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentoDinheiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoDinheiro);
        }

        // POST: PagamentoDinheiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            db.PagamentoDinheiroes.Remove(pagamentoDinheiro);
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
