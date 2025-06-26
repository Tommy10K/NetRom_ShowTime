using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => new { b.UserId, b.FestivalId });

            builder.Property(b => b.Type)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Price)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(l => l.UserId);

            builder.HasOne(b => b.Festival)
                .WithMany(f => f.Bookings)
                .HasForeignKey(l => l.FestivalId);
        }
    }
}
