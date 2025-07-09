using System.Net.Sockets;

namespace ShowTime.DataAccess.Models;

public class Festival
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string SplashArt { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public virtual ICollection<Lineup> Lineups { get; set; } = new List<Lineup>();
    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
