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
    public class TipoCombustivelController : Controller
    {
        private FrotadeVeículoEntities1 db = new FrotadeVeículoEntities1();

        // GET: TipoCombustivels
        public ActionResult Index()
        {
            return View(db.TipoCombustivels.ToList());
        }

        // GET: TipoCombustivels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivels.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCombustivels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CombId,ValorLitro,Nome")] TipoCombustivel tipoCombustivel)
        {
            if (ModelState.IsValid)
            {
                db.TipoCombustivels.Add(tipoCombustivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCombustivel);
        }

        // GET: TipoCombustivels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivels.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // POST: TipoCombustivels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CombId,ValorLitro,Nome")] TipoCombustivel tipoCombustivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCombustivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivels.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // POST: TipoCombustivels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCombustivel tipoCombustivel = db.TipoCombustivels.Find(id);
            db.TipoCombustivels.Remove(tipoCombustivel);
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
