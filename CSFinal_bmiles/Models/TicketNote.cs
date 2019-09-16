using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSFinal_bmiles.Models
{
    public class TicketNote
    {
        [Key]
        public int NoteID { get; set; }

        public string NoteMessage { get; set; }
        public DateTime NoteTime { get; set; }
        public string UserId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}