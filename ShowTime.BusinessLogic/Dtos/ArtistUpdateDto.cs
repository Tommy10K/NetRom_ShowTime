using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Dtos
{
    public class ArtistUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; } = string.Empty;
    }
}
