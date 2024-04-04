using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Frota_de_Veículos.Models;

namespace Frota_de_Veículos.Controllers
{
    public class OrdemServicoController : Controller
    {
        private FrotadeVeículoEntities1 db = new FrotadeVeículoEntities1();

        // GET: OrdemServico
        public ActionResult Index()
        {
            var ordemServicoes = db.OrdemServicoes.Include(o => o.Motorista).Include(o => o.TipoCombustivel);
            return View(ordemServicoes.ToList());
        }

        // GET: OrdemServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServicoes.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public ActionResult Create()
        {
            ViewBag.MotId = new SelectList(db.Motoristas, "MotId", "Nome");
            ViewBag.CombId = new SelectList(db.TipoCombustivels, "CombId", "Nome");
            return View();
        }

        // POST: OrdemServico/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdSerId,Data,QuantidadeCombustivel,MotId,CombId")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.OrdemServicoes.Add(ordemServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MotId = new SelectList(db.Motoristas, "MotId", "Nome", ordemServico.MotId);
            ViewBag.CombId = new SelectList(db.TipoCombustivels, "CombId", "Nome", ordemServico.CombId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServicoes.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotId = new SelectList(db.Motoristas, "MotId", "Nome", ordemServico.MotId);
            ViewBag.CombId = new SelectList(db.TipoCombustivels, "CombId", "Nome", ordemServico.CombId);
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdSerId,Data,QuantidadeCombustivel,MotId,CombId")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotId = new SelectList(db.Motoristas, "MotId", "Nome", ordemServico.MotId);
            ViewBag.CombId = new SelectList(db.TipoCombustivels, "CombId", "Nome", ordemServico.CombId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServicoes.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemServico ordemServico = db.OrdemServicoes.Find(id);
            db.OrdemServicoes.Remove(ordemServico);
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
