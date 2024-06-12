using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TDVBaiKiemTraGiuaKy.Models;

namespace TDVBaiKiemTraGiuaKy.Controllers
{
    public class TDVKhoasController : Controller
    {
        private TDVK22CNT3Lesson07DbEntities2 db = new TDVK22CNT3Lesson07DbEntities2();

        // GET: TDVKhoas
        public ActionResult TDVIndex()
        {
            return View(db.TDVKhoas.ToList());
        }

        // GET: TDVKhoas/Details/5
        public ActionResult TDVDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TDVKhoa tDVKhoa = db.TDVKhoas.Find(id);
            if (tDVKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tDVKhoa);
        }

        // GET: TDVKhoas/Create
        public ActionResult TDVCreate()
        {
            return View();
        }

        // POST: TDVKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVCreate([Bind(Include = "TDVMaKH,TDVTenKH,TDVTrangThai")] TDVKhoa tDVKhoa)
        {
            if (ModelState.IsValid)
            {
                db.TDVKhoas.Add(tDVKhoa);
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }

            return View(tDVKhoa);
        }

        // GET: TDVKhoas/Edit/5
        public ActionResult TDVEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TDVKhoa tDVKhoa = db.TDVKhoas.Find(id);
            if (tDVKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tDVKhoa);
        }

        // POST: TDVKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVEdit([Bind(Include = "TDVMaKH,TDVTenKH,TDVTrangThai")] TDVKhoa tDVKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tDVKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }
            return View(tDVKhoa);
        }

        // GET: TDVKhoas/Delete/5
        public ActionResult TDVDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TDVKhoa tDVKhoa = db.TDVKhoas.Find(id);
            if (tDVKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tDVKhoa);
        }

        // POST: TDVKhoas/Delete/5
        [HttpPost, ActionName("TDVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TDVDeleteConfirmed(string id)
        {
            TDVKhoa tDVKhoa = db.TDVKhoas.Find(id);
            db.TDVKhoas.Remove(tDVKhoa);
            db.SaveChanges();
            return RedirectToAction("TDVIndex");
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
