using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //TODO: Aşağıdakiler Navigation propertydir.

        /// <summary>
        ///Bir productın da birden fazla categorysi olabilir.
        ///Bunlar Navigation propertydir.
        /// </summary>
        [ForeignKey("CategoryId")]
        public ICollection<Category> Categories { get; set; }
        public ProductFeature ProductFeature { get; set; }

        /// <summary>
        /// NOT:
        /// "?" koyulmasının sebebi: Uygulama çalıştığında Nullable Exception hatası alma durumunu azaltır.
        ///genllikle uygulama da altı yeşil tırtıklı olan nesnelerin null olma ihtimali olduğu için uyarır.
        ///Eğer bu alanalardan herhangisi Null olmasını istemiyorsak , nullabble özelliğini kapatabiliriz.
        /// </summary>

    }
}
