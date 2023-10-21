using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        ///Seed Data --> VT nında tablo oluşturuken defuşt olarak bazı dataların oluşmasını ya da kayıt edilmesini sağlar.
        ///Bunu migration ile yapıcaz asıl  , bu yöntemi 2. olarak düşünebiliriz.
        /// </summary>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
               new Category { Id = 1, Name = "Kalemler" },
               new Category { Id = 2, Name = "Defterler" }

         );
            //Sadece seed data  da ıd kısmı veriir.
        }
    }
}
