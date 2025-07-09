using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Dtos
{
    public class BookingGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FestivalId { get; set; }
        public int TicketId { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
