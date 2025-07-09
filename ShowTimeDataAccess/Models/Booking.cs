using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DataAccess.Models;
public class Booking
{
    public int Id { get; set; }
    public int FestivalId { get; set; }
    public int UserId { get; set; }
    public int TicketId { get; set; }
    public DateTime BookingTime { get; set; }
    public virtual Festival Festival { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual Ticket Ticket { get; set; } = null!;
}
