using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public  class ProductUpdateDto
    {
        //Bu Dto'yu oluşturma sebebim ; bu methodun requesti ve responsunda bu propertleri esas alması.
        /// <summary>
        /// Burada methoda özel bir Dto oluşturdum bu sayede gerekli propları kullandım.
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
