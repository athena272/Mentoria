using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Check2.Context;
using Check2.Models;

namespace Check2.Controllers
{
    public class CaesController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Caes
        public ActionResult Index(int? search)
        {
            List<Caes> All = db.Caes.ToList();
            foreach (Caes item in All)
            {

                var NmRaca = db.Racas.Where(t => t.Idraca == item.Idraca).FirstOrDefault();
                item.Nome_raca = NmRaca.Nome_raca;

                var NmDono = db.Donos.Where(t => t.Iddono == item.Iddono).FirstOrDefault();
                item.Nome_dono = NmDono.Nome_dono;  
                
            }
            List<Racas> Racas = db.Racas.ToList();
            ViewBag.Raca_index = Racas;
            List<Donos> Donos = db.Donos.ToList();
            ViewBag.Dono_index = Donos;

            //Start of search code

            if (search != null) 
            {
            
                List<Caes> Searchlist = db.Caes.ToList();
                Searchlist = Searchlist.Where(t => t.Idraca == search ).ToList();

                foreach (Caes item in Searchlist)
                {
                    var Rcao = db.Caes.Where(t => t.Idcao == item.Idcao).FirstOrDefault();
                    var Rdono = db.Donos.Where(t => t.Iddono == item.Iddono).FirstOrDefault();

                    item.Idraca = Rcao.Idraca;

                    var Rraca = db.Racas.Where(t => t.Idraca == item.Idraca).FirstOrDefault();

                    item.Nome_cao = Rcao.Nome_cao;
                    item.Nome_dono = Rdono.Nome_dono;
                    item.Nome_raca = Rraca.Nome_raca;

                }
                return View(Searchlist);
            }
            //End of search Code
            return View(db.Caes.ToList());  
        }
        
        //[HttpPost]
        //public PartialViewResult Listing(int Idraca)
        // {
        //    var idfind = db.Racas.Include(s => s.Idraca).Where(x => x.Idraca == Idraca);
        //    return PartialView(db.Racas.ToList());
        //}
        // GET: Caes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caes caes = db.Caes.Find(id);
            if (caes == null)
            {
                return HttpNotFound();
            }
            List<Caes> All = db.Caes.ToList();

            foreach (Caes item in All)
            {
                var NmRaca = db.Racas.Where(t => t.Idraca == item.Idraca).FirstOrDefault();
                item.Nome_raca = NmRaca.Nome_raca;

                var NmDono = db.Donos.Where(t => t.Iddono == item.Iddono).FirstOrDefault();
                item.Nome_dono = NmDono.Nome_dono;
            }
            return View(caes);
        }

        // GET: Caes/Create
        public ActionResult Create()
        {
            //O BRABO
            List<Racas> Racas = db.Racas.ToList();
            List<Donos> Donos = db.Donos.ToList();
            ViewBag.Raca = Racas;
            ViewBag.Dono = Donos;
            return View();
        }

        // POST: Caes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idcao,Nome_cao,Idraca,Nome_raca,Iddono,Nome_dono")] Caes caes)
        {
            if (ModelState.IsValid)
            {
                db.Caes.Add(caes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caes);
        }

        // GET: Caes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caes caes = db.Caes.Find(id);
            if (caes == null)
            {
                return HttpNotFound();
            }
            List<Caes> All = db.Caes.ToList();
            foreach (Caes item in All)
            {
                var NmRaca = db.Racas.Where(t => t.Idraca == item.Idraca).FirstOrDefault();
                item.Nome_raca = NmRaca.Nome_raca;

                var NmDono = db.Donos.Where(t => t.Iddono == item.Iddono).FirstOrDefault();
                item.Nome_dono = NmDono.Nome_dono;
            }
            return View(caes);
        }

        // POST: Caes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idraca,Nome_cao,Idraca,Nome_raca,Iddono,Nome_dono")] Caes caes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caes);
        }

        // GET: Caes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caes caes = db.Caes.Find(id);
            if (caes == null)
            {
                return HttpNotFound();
            }
            return View(caes);
        }

        // POST: Caes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caes caes = db.Caes.Find(id);
            db.Caes.Remove(caes);
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
