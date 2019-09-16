using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSFinal_bmiles.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CSFinal_bmiles.Controllers
{
    public class TicketsController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();
        string currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;

        private List<Ticket> TicketsWithNames()
        {
            List<Ticket> OpenTickets = new List<Ticket>();
            string currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;
            ICollection<Ticket> YourRawOpenTickets = db.Tickets.SqlQuery("SELECT * FROM Tickets").ToList();
            foreach (Ticket ticket in YourRawOpenTickets)
            {
                ticket.SetUserName();
                OpenTickets.Add(ticket);
            }
            return OpenTickets.ToList();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            return View(TicketsWithNames());
        }

        // GET: Tickets/YourOpenTickets
        public ActionResult YourOpenTickets()
        {
            /* workaround for relationship between objects and users. */
            List<Ticket> OpenTickets = new List<Ticket>();
            string currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;
            ICollection<Ticket> YourRawOpenTickets = db.Tickets.SqlQuery("SELECT * FROM Tickets AS t WHERE t.UserId =N\'" + currentUser + "\' AND t.ClosedDate IS NULL ").ToList();
            foreach ( Ticket ticket in YourRawOpenTickets )
            {
                ticket.SetUserName();
                OpenTickets.Add(ticket);
            }
            return View(OpenTickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,Message,OpenStatus,Priority,")] Ticket ticket)
        {
            
            if (ModelState.IsValid)
            {
                
                ticket.UserId = currentUser;
                ticket.Date = DateTime.Now;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,Message,Date,OpenStatus,Priority")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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


        // GET: Tickets/Close/5
        public ActionResult Close(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            ticket.ClosedDate = System.DateTime.Now;
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();

            return View(ticket);
        }
    }
}
