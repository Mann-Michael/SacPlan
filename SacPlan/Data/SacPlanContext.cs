using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacPlan.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SacPlan.Data
{
    public class SacPlanContext : DbContext
    {
        public SacPlanContext(DbContextOptions<SacPlanContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
        }
    }
}