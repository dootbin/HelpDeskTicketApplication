using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSFinal_bmiles.Models
{
    public class Ticket
    {

        public int TicketId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int Priority { get; set; }

        public string UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }

        private ApplicationDbContext db = new ApplicationDbContext();

        public void SetUserName()
        {
            UserName = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(UserId).UserName;
        }

    }

}