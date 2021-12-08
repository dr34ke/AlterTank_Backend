using AlterTankBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Database
{
    public class Configuration : IEntityTypeConfiguration<Stations>
    {
        public void Configure(EntityTypeBuilder<Stations> builder)
        {
            builder.HasKey(prop => prop.id);
        }
    }
}
