using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Dtos
{
    public class LineupUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public int FestivalId { get; set; }

        [Required]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Stage name is required")]
        public string Stage { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }
    }
}
