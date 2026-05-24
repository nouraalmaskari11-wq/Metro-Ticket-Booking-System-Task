using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketSystem.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
