using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketSystem.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
