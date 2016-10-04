using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityLibrary;
using BusinessLogicLibrary;

namespace MVCEntityFramework.Controllers
{
    public class SalesReasonsController : Controller
    {
        private AdventureWorks2008Entities db = new AdventureWorks2008Entities();
        private CRUDManager data = new CRUDManager();

        // GET: SalesReasons
        public ActionResult Index()
        {
            return View(data.RetrieveUsingQuery());
        }

        // GET: SalesReasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = data.RetrieveUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // GET: SalesReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesReason salesReason)
        {
            if (ModelState.IsValid)
            {
                data.AddSalesReason(salesReason);
                return RedirectToAction("Index");
            }

            return View(salesReason);
        }

        // GET: SalesReasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = data.RetrieveUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // POST: SalesReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesReason salesReason)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(salesReason).State = EntityState.Modified;
                data.UpdateSalesReason(salesReason);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesReason);
        }

        // GET: SalesReasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReason salesReason = data.RetrieveUsingLambda(id);
            if (salesReason == null)
            {
                return HttpNotFound();
            }
            return View(salesReason);
        }

        // POST: SalesReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SalesReason salesReason = db.SalesReasons.Find(id);
            //db.SalesReasons.Remove(salesReason);
            data.DeleteSalesReason(id);
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
