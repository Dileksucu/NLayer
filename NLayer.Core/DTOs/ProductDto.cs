using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductDto:BaseDto
    {
        /// <summary>
        /// Dto'larda Navigation Propertylerine gerek yoktur, kullanılmaz.
        /// </summary>
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        //public int CategoryId { get; set; } ?? neden kullandı 

    }
}
