using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Dtos
{
    public class BookingUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public int FestivalId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TicketId { get; set; }
        
        [Required]
        public DateTime BookingTime { get; set; }
    }
}
