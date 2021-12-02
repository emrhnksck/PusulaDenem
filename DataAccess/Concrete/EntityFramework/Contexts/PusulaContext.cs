using DataAccess.Concrete.EntityFramework.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class PusulaContext:DbContext
    {
        public DbSet<Nufus> Nufuslar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-H9TFJ7H\SQLEXPRESS;Database=PusulaDenem;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NufusMap());
        }
    }
}
