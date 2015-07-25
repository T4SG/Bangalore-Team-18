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
using System.Security.Principal;

namespace ITSnooze.Controllers
{
    public class Azure_Snooze_WeekendController : Controller
    {
        private ITSnoozeEntities db = new ITSnoozeEntities();
        static private string f;
        //f is a flag variable to ensure the validationof SnoozeStart < SnoozeEnd Date Time
        static private string startdatevalue;
        static private string stopdatevalue;
       

        // GET: Azure_Snooze_Weekend
        public ActionResult Index()
        {
            return View(db.Azure_Snooze_Weekend.ToList());
        }

        // GET: Azure_Snooze_Weekend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Weekend azure_Snooze_Weekend = db.Azure_Snooze_Weekend.Find(id);
            if (azure_Snooze_Weekend == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Weekend);
        }
        public string GetServerNames(string EngTeamName)
        {
            //Used to populate server names based upon the Appgroup Selected
            if (String.IsNullOrEmpty(EngTeamName))
            {
                throw new ArgumentNullException("EngTeamName");
            }

            var q3 = (from s in db.Azure_Snooze_Weekend
                      where s.AppTeam == EngTeamName
                      select new
                      {
                          id = s.Server,
                          name = s.Server
                      }).ToList();
            return JsonConvert.SerializeObject(q3);
        }

        public string GetServerDates(string ServerName)
        {
            //Used to populate Snooze start and end datetime based on server selected
            if (String.IsNullOrEmpty(ServerName))
            {
                throw new ArgumentNullException("ServerName");
            }

            var q3 = (from s in db.Azure_Snooze_Weekend
                      where s.Server == ServerName
                      select new
                      {
                          dateStart = s.SnoozeStart,
                          dateEnd = s.SnoozeEnd
                      });
            return JsonConvert.SerializeObject(q3);
        }
        public void getdetails(string x, string y, string flag, string z)
        {
            //result of ajax call
            startdatevalue = x;
            stopdatevalue = y;
            f = flag;
        }
        // GET: Azure_Snooze_Weekend/Create
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
            //li1 contains the list of distinct AppGroups passed to view using ViewData
            ViewData["AppTeam"] = li1;
            return View();
        }

        // POST: Azure_Snooze_Weekend/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Server,AppTeam,LastModifiedTime,LastModifiedBy,ID")] Azure_Snooze_Weekend azure_Snooze_Weekend)
        {
            //Used to update the fields of selected server in the table.
                if(f == "0" )
                {
                    return RedirectToAction("Create");
                }
           
                string servers = azure_Snooze_Weekend.Server;
                azure_Snooze_Weekend = (from s in db.Azure_Snooze_Weekend
                                        where s.Server == servers
                                        select s).FirstOrDefault<Azure_Snooze_Weekend>();
                azure_Snooze_Weekend.LastModifiedBy = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                azure_Snooze_Weekend.LastModifiedTime = System.DateTime.Now;
                string y = Request["Exception"];
                string z = Request["Time"];
                if (y == "True")
                {
                    azure_Snooze_Weekend.Exception = true;
                }
                else if (y != "True")
                {
                    azure_Snooze_Weekend.Exception = false;
                }

                if (z == "True")
                {
                    azure_Snooze_Weekend.SnoozeStart = Convert.ToDateTime(stopdatevalue);
                    azure_Snooze_Weekend.SnoozeEnd = Convert.ToDateTime(startdatevalue);
                }
                ITSnoozeEntities db2 = new ITSnoozeEntities();
                db2.Entry(azure_Snooze_Weekend).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Azure_Snooze_Weekend/Edit/5
        public ActionResult Edit(int? id)
        {
            //NOT BEING USED IN THIS PROJECT
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Weekend azure_Snooze_Weekend = db.Azure_Snooze_Weekend.Find(id);
            if (azure_Snooze_Weekend == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Weekend);
        }

        // POST: Azure_Snooze_Weekend/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Server,AppTeam,Exception,SnoozeStart,SnoozeEnd,StartStatus,StopStatus,LastModifiedBy,LastModifiedTime,ID")] Azure_Snooze_Weekend azure_Snooze_Weekend)
        {
            //NOT BEING USED IN THIS PROJECT
            if (ModelState.IsValid)
            {
                db.Entry(azure_Snooze_Weekend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(azure_Snooze_Weekend);
        }

        // GET: Azure_Snooze_Weekend/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azure_Snooze_Weekend azure_Snooze_Weekend = db.Azure_Snooze_Weekend.Find(id);
            if (azure_Snooze_Weekend == null)
            {
                return HttpNotFound();
            }
            return View(azure_Snooze_Weekend);
        }

        // POST: Azure_Snooze_Weekend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Azure_Snooze_Weekend azure_Snooze_Weekend = db.Azure_Snooze_Weekend.Find(id);
            db.Azure_Snooze_Weekend.Remove(azure_Snooze_Weekend);
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
