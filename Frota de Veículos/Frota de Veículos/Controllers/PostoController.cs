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
    public class PostoController : Controller
    {
        private FrotadeVeículoEntities1 db = new FrotadeVeículoEntities1();

        // GET: Posto
        public ActionResult Index()
        {
            var postoes = db.Postoes.Include(p => p.OrdemServico);
            return View(postoes.ToList());
        }

        // GET: Posto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posto posto = db.Postoes.Find(id);
            if (posto == null)
            {
                return HttpNotFound();
            }
            return View(posto);
        }

        // GET: Posto/Create
        public ActionResult Create()
        {
            ViewBag.OrdSerId = new SelectList(db.OrdemServicoes, "OrdSerId", "OrdSerId");
            return View();
        }

        // POST: Posto/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoId,Nome,Localizacao,OrdSerId")] Posto posto)
        {
            if (ModelState.IsValid)
            {
                db.Postoes.Add(posto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrdSerId = new SelectList(db.OrdemServicoes, "OrdSerId", "OrdSerId", posto.OrdSerId);
            return View(posto);
        }

        // GET: Posto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posto posto = db.Postoes.Find(id);
            if (posto == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdSerId = new SelectList(db.OrdemServicoes, "OrdSerId", "OrdSerId", posto.OrdSerId);
            return View(posto);
        }

        // POST: Posto/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoId,Nome,Localizacao,OrdSerId")] Posto posto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdSerId = new SelectList(db.OrdemServicoes, "OrdSerId", "OrdSerId", posto.OrdSerId);
            return View(posto);
        }

        // GET: Posto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posto posto = db.Postoes.Find(id);
            if (posto == null)
            {
                return HttpNotFound();
            }
            return View(posto);
        }

        // POST: Posto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posto posto = db.Postoes.Find(id);
            db.Postoes.Remove(posto);
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
