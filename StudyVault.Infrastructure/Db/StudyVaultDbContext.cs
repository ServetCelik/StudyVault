using Microsoft.EntityFrameworkCore;
using StudyVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Infrastructure.Db
{
    public class StudyVaultDbContext : DbContext
    {
        public StudyVaultDbContext(DbContextOptions<StudyVaultDbContext> options)
            : base(options) { }

        public DbSet<StudyNote> StudyNotes => Set<StudyNote>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyNote>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Summary).IsRequired();
                entity.Property(e => e.Subject).IsRequired();
                entity.Property(e => e.Difficulty).IsRequired();
                entity.Property(e => e.AuthorName).IsRequired();

                // Store Tags as a comma-separated string
                entity.Property(e => e.Tags)
                      .HasConversion(
                          tags => string.Join(',', tags),
                          str => str.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                      );
            });
        }
    }
}
