using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class ProductFeature
    {
        /// <summary>
        ///BaseEntity vermeme gerek yok nedeni de her Productın,ProductFeature olacağı için
        ///Buradaki amaç Product tablosuna fazla alan yüklemeden bu kısımları ayrı bir entitiy de tutmaktır.
        /// </summary>
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        //Bunu sistem direkt Foreign key olarak algılar boşluksuz olduğu için.
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}
