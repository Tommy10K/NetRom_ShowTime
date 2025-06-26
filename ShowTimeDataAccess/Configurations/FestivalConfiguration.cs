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
    public class FestivalConfiguration : IEntityTypeConfiguration<Festival>
    {
        public void Configure(EntityTypeBuilder<Festival> builder)
        {
            builder.ToTable("Festivals");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(a => a.Location)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.EndDate).IsRequired();
            builder.Property(a => a.SplashArt).IsRequired();
            builder.Property(a => a.Capacity).IsRequired();
        }
    }
}
