using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //bu şekilde vt da tablo oluştuğunda bu verileri direkt ekler.Default olarak)
            builder.HasData
            (
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Tükenmez Kalem",
                    Price = 500,
                    Stock = 10,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Kurşun Kalem",
                    Price = 150,
                    Stock = 1000,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                     Id = 3,
                     CategoryId = 2,
                     Name = "Telli Defter",
                     Price = 150,
                     Stock = 100,
                     CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
