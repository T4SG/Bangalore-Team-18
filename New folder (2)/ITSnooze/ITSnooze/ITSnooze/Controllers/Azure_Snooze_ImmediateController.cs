using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITSnooze.Models;
using Newtonsoft.Json;

namespace ITSnooze.Controllers
{
    public class Azure_Snooze_ImmediateController : Controller
    {
        private ITSnoozeEntities db = new ITSnoozeEntities();


        // GET: Azure_Snooze_Immediate
        public ActionResult Index()
        {
            return View(db.Azure_Snooze_Immediate.ToList());
        }

        // GET: Azure_Snooze_Immediate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Immediate azure_Snooze_Immediate = db.Azure_Snooze_Immediate.Find(id);
            if (azure_Snooze_Immediate == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Immediate);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public string GetServerNames(string AppTeamName)
        {
            //Used to populate server names based upon the Appgroup Selected
            if (String.IsNullOrEmpty(AppTeamName))
            {
                throw new ArgumentNullException("AppTeamName");
            }
            var q3 = (from s in db.Azure_Snooze_Weekend
                      where s.AppTeam == AppTeamName
                      select new
                      {
                          id = s.Server,
                          name = s.Server
                      }).ToList();
            return JsonConvert.SerializeObject(q3);
        }

        // GET: Azure_Snooze_Immediate/Create
        public ActionResult Create()
        {
            List<SelectListItem> li1 = new List<SelectListItem>();
            var query = (from s in db.Azure_Snooze_Weekend
                         select s.AppTeam).Distinct().ToList<string>();
            li1.Add(new SelectListItem { Text = "Select", Value = "0" });
            foreach (string item in query)
            {
                li1.Add(new SelectListItem { Text = item, Value = item });
            }
            List<SelectListItem> li2 = new List<SelectListItem>();
            li2.Add(new SelectListItem { Text = "Unsnooze", Value = "0" });
            li2.Add(new SelectListItem { Text = "Snooze", Value = "1" });
            //li1 contains the list of AppGroups and li2 contains the Flag list
            ViewData["AppTeam"] = li1;
            ViewData["Flag"] = li2;
            return View();        
        }

        // POST: Azure_Snooze_Immediate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Server,AppTeam,Flag,LastModifiedBy,LastModifiedTime,ID")] Azure_Snooze_Immediate azure_Snooze_Immediate)
        {
            if (ModelState.IsValid)
            {
                db.Azure_Snooze_Immediate.Add(azure_Snooze_Immediate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(azure_Snooze_Immediate);
        }

        // GET: Azure_Snooze_Immediate/Edit/5
        public ActionResult Edit(int? id)
        {
            //NOT BEING USED IN THIS PROJECT
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Immediate azure_Snooze_Immediate = db.Azure_Snooze_Immediate.Find(id);
            if (azure_Snooze_Immediate == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Immediate);
        }

        // POST: Azure_Snooze_Immediate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Server,AppTeam,Flag,LastModifiedBy,LastModifiedTime,ID")] Azure_Snooze_Immediate azure_Snooze_Immediate)
        {
            //NOT BEING USED IN THIS PROJECT
            if (ModelState.IsValid)
            {
                db.Entry(azure_Snooze_Immediate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(azure_Snooze_Immediate);
        }

        // GET: Azure_Snooze_Immediate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Immediate azure_Snooze_Immediate = db.Azure_Snooze_Immediate.Find(id);
            if (azure_Snooze_Immediate == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Immediate);
        }

        // POST: Azure_Snooze_Immediate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Azure_Snooze_Immediate azure_Snooze_Immediate = db.Azure_Snooze_Immediate.Find(id);
            db.Azure_Snooze_Immediate.Remove(azure_Snooze_Immediate);
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
