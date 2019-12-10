using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsAssignmentAPI.Domain.Models;

namespace ProductsAssignmentAPI.EntityConfigurations
{
    class ProductTypeEntityTypeConfiguration: IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
