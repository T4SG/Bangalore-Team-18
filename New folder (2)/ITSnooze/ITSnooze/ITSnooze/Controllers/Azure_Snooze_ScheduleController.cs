using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITSnooze.Models;

namespace ITSnooze.Controllers
{
    public class Azure_Snooze_ScheduleController : Controller
    {
        private ITSnoozeEntities db = new ITSnoozeEntities();
        static private string f;
        //f is a flag variable to ensure the validationof SnoozeStart < SnoozeEnd Date Time
        static private string startdatevalue;
        static private string stopdatevalue;

        // GET: Azure_Snooze_Schedule
        public ActionResult Index()
        {
            return View(db.Azure_Snooze_Schedule.ToList());
        }

        // GET: Azure_Snooze_Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Schedule azure_Snooze_Schedule = db.Azure_Snooze_Schedule.Find(id);
            if (azure_Snooze_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Schedule);
        }

        // GET: Azure_Snooze_Schedule/Create
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
            ViewData["AppTeam"] = li1;
            ViewData["Flag"] = li2;
            //li1 contains the list of AppGroups and li2 contains the Flag list
            return View();
        }

        public void getdetails(string x, string y, string flag)
        {
            startdatevalue = x;
            stopdatevalue = y;
            f = flag;
        }

        // POST: Azure_Snooze_Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Server,Flag,LastModifiedBy,LastModifiedTime,ID,AppTeam")] Azure_Snooze_Schedule azure_Snooze_Schedule)
        {
            if (f == "0")
            {
                return RedirectToAction("Create");
            }
            //Making two entries into the database from one request.
            //So, creation of two database objects: azure_Snooze_Schedule and azure_Snooze_Schedule2
                string input = startdatevalue;
                string input1 = stopdatevalue;
                azure_Snooze_Schedule.Time = Convert.ToDateTime(input);
                azure_Snooze_Schedule.Flag = 1;
                Azure_Snooze_Schedule azure_Snooze_Schedule2 = new Azure_Snooze_Schedule();
                azure_Snooze_Schedule2.Flag = 0;
                azure_Snooze_Schedule2.AppTeam = Request["AppTeam"].ToString();
                azure_Snooze_Schedule2.Time = Convert.ToDateTime(input1);
                azure_Snooze_Schedule2.LastModifiedBy = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                azure_Snooze_Schedule2.LastModifiedTime = System.DateTime.Now;
                azure_Snooze_Schedule2.Server = Request["Server"].ToString();
                db.Azure_Snooze_Schedule.Add(azure_Snooze_Schedule2);
                if (ModelState.IsValid)
                {
                    db.Azure_Snooze_Schedule.Add(azure_Snooze_Schedule);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(azure_Snooze_Schedule);
        }



        // GET: Azure_Snooze_Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            //NOT BEING USED IN THIS PROJECT
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Schedule azure_Snooze_Schedule = db.Azure_Snooze_Schedule.Find(id);
            if (azure_Snooze_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Schedule);
        }

        // POST: Azure_Snooze_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Server,Flag,Time,LastModifiedBy,LastModifiedTime,ID,AppTeam")] Azure_Snooze_Schedule azure_Snooze_Schedule)
        {
            //NOT BEING USED IN THIS PROJECT
            if (ModelState.IsValid)
            {
                db.Entry(azure_Snooze_Schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(azure_Snooze_Schedule);
        }

        // GET: Azure_Snooze_Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Schedule azure_Snooze_Schedule = db.Azure_Snooze_Schedule.Find(id);
            if (azure_Snooze_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Schedule);
        }

        // POST: Azure_Snooze_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Azure_Snooze_Schedule azure_Snooze_Schedule = db.Azure_Snooze_Schedule.Find(id);
            db.Azure_Snooze_Schedule.Remove(azure_Snooze_Schedule);
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
