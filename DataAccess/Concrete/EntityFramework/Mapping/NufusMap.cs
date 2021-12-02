using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class NufusMap : IEntityTypeConfiguration<Nufus>
    {
        public void Configure(EntityTypeBuilder<Nufus> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Name).IsRequired();
            builder.ToTable("Nufuslar");
            builder.HasData(new Nufus
            {
                Id = 1,
                Name = "Emrehan",
                Surname = "Kısacık"
            });
        }

    }
}
