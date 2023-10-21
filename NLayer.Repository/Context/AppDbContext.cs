using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Context
{
    public class AppDbContext:DbContext
    {
        /// <summary>
        ///Veritabanı yolunu program.cs den vericem bundan dolayı da bu yolu kolaylıkla verebilmek için
        ///bir ctor oluşturuyorum ve içerisine bu şekilde parametre veriyorum.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            var p = new Product() { ProductFeature = new ProductFeature() { } };
            // ProductFeature entitysini Dbset  ile eklemiyorum da burada Productın içinden ekliyorum.
        }

        /// <summary>
        /// Her entitye karşılık DbSet ile Vtnında tablo oluştururuz.
        ///default hali propertylerin private olduğumdam
        ///başka katmanlardan erişmek için public erişim belirteci koyuyorum.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Düzenlemeler ve eklemeler bu method ile yapılıyor.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bu assembly olan dosyaları okumaya yardımcı olur.
            //Biz de assemblydeki olan tüm ınterfaceleri bulup okumasını sağlaması için kullandık.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
