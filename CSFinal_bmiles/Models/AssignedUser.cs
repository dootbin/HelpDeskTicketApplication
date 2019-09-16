using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSFinal_bmiles.Models
{
    public class AssignedUser
    {
        [Key]
        public int AssignedUserKey { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}