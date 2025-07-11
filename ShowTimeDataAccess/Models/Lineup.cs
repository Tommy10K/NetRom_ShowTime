﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DataAccess.Models
{
    public class Lineup
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public int ArtistId { get; set; }
        public string Stage { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public virtual Festival Festival { get; set; } = null!;
        public virtual Artist Artist { get; set; } = null!;
    }
}
