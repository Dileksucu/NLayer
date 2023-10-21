using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public ICollection<Category> Categories { get; set; }
        //Bir productın da birden fazla categorysi olabilir.
        //Bunlar Navigation propertydir.
        public ProductFeature ProductFeature { get; set; } 
        //Bunlar Navigation propertydir.

        // "?" koyulmasının sebebi: Uygulama çalıştığında Nullable Exception hatası alma durumunu azaltır.
        //genllikle uygulama da altı yeşşil tırtıklı olan nesnelerin null olma ihtimali olduğu için uyarır.

        //Eğer bu alanalardan herhangisi Null olmasını istemiyorsak , nullabble özelliğini kapatabiliriz.
    }
}
