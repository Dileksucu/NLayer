﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.HasOne(x => x.Products).WithOne(x => x.ProductFeature)
                .HasForeignKey<ProductFeature>(x => x.ProductId);
            //EF Core bunları otomatik anlar, öğrenmek için yazdım.
            //Bir productın bir tane productFeature olabilir dedik.(bire bir ilişki olduğu için)

        }
    }
}
