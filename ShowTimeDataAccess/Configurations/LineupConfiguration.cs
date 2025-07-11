﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations
{
    public class LineupConfiguration : IEntityTypeConfiguration<Lineup>
    {
        public void Configure(EntityTypeBuilder<Lineup> builder)
        {
            builder.ToTable("Lineups");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Stage)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(l => l.StartTime)
                .IsRequired();

            builder.HasOne(l => l.Artist)
                .WithMany(a => a.Lineups)
                .HasForeignKey(l => l.ArtistId);

            builder.HasOne(l => l.Festival)
                .WithMany(f => f.Lineups)
                .HasForeignKey(l => l.FestivalId);
        }
    }
}
