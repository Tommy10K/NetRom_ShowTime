using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Dtos
{
    public class FestivalCreateDto
    {

        [Required(ErrorMessage = "Please enter a festival name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a location.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Splash art URL is required.")]
        [Url(ErrorMessage = "That doesn’t look like a valid URL.")]
        public string SplashArt { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }
    }
}
