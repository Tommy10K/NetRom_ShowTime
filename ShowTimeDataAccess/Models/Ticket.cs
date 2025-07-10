using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DataAccess.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity {  get; set; }
        public int SoldCount { get; set; }

        public virtual Festival Festival { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
