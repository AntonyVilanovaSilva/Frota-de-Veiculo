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
    public class MotoristaController : Controller
    {
        private FrotadeVeículoEntities1 db = new FrotadeVeículoEntities1();

        // GET: Motoristas
        public ActionResult Index()
        {
            var motoristas = db.Motoristas.Include(m => m.Veiculo);
            return View(motoristas.ToList());
        }

        // GET: Motoristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // GET: Motoristas/Create
        public ActionResult Create()
        {
            ViewBag.VeId = new SelectList(db.Veiculoes, "VeId", "VeiPlaca");
            return View();
        }

        // POST: Motoristas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotId,Nome,Idade,VeId")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Motoristas.Add(motorista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VeId = new SelectList(db.Veiculoes, "VeId", "VeiPlaca", motorista.VeId);
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            ViewBag.VeId = new SelectList(db.Veiculoes, "VeId", "VeiPlaca", motorista.VeId);
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotId,Nome,Idade,VeId")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VeId = new SelectList(db.Veiculoes, "VeId", "VeiPlaca", motorista.VeId);
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorista motorista = db.Motoristas.Find(id);
            db.Motoristas.Remove(motorista);
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
