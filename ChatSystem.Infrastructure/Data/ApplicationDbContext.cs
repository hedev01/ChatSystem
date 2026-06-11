using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using ChatSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Message> Message { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Content)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(x => x.SenderId)
                    .IsRequired();

                entity.Property(x => x.ReceiverId)
                    .IsRequired();
            });
        }
    }
}
