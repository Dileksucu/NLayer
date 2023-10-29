using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> //Bu ınterface üzerinden implementasyon ile aşağıdaki method gelir.
    {
        /// <summary>
        /// Burada entity içindeki propertylerin özelliklerini ya da kullanımıyla ilgili config değişikler yapar .
        /// </summary>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); //Id kısmı PK dedik mesela
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            //Burada name  alanı zorunlu ve max karakter olmalı dedik.
        }
    }
}
