using Microsoft.EntityFrameworkCore;
using MovieSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Data.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options) // Pass options to the base class
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmBox> FilmBoxes { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<FilmTag> FilmTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Film Configuration
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.FilmID);
                entity.Property(e => e.FilmTitle).HasMaxLength(400).IsRequired();
                entity.Property(e => e.CoverImage).HasMaxLength(800);
                entity.Property(e => e.RegDate).HasDefaultValueSql("GETDATE()");
            });

            // Box Configuration
            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasKey(e => e.BoxID);
                entity.Property(e => e.BoxName).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Slug).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SortOrder).IsRequired();
            });

            // FilmBox Configuration (Many-to-Many)
            modelBuilder.Entity<FilmBox>(entity =>
            {
                entity.HasKey(fb => new { fb.FilmID, fb.BoxID });

                entity.HasOne(fb => fb.Film)
                    .WithMany(f => f.FilmBoxes)
                    .HasForeignKey(fb => fb.FilmID);

                entity.HasOne(fb => fb.Box)
                    .WithMany(b => b.FilmBoxes)
                    .HasForeignKey(fb => fb.BoxID);
            });

            // FilmTag Configuration
            modelBuilder.Entity<FilmTag>(entity =>
            {
                entity.HasKey(e => e.FilmTagID);
                entity.HasOne(e => e.Film)
                    .WithMany(f => f.FilmTags)
                    .HasForeignKey(e => e.FilmID);
                entity.HasOne(e => e.Tag)
                    .WithMany(t => t.FilmTags)
                    .HasForeignKey(e => e.TagID);
            });

            // Tag Configuration
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagID);
                entity.Property(e => e.TagText).HasMaxLength(200);
                entity.Property(e => e.RegDate).HasDefaultValueSql("GETDATE()");
            });
        }
    }

}
