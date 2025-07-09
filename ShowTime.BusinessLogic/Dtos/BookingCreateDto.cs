using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShowTime.BusinessLogic.Dtos
{
    public class BookingCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int FestivalId { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public DateTime BookingTime { get; set; } = DateTime.Now;
    }
}
