using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShowTime.BusinessLogic.Dtos
{
    public class ArtistCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; } = string.Empty;
    }
}
