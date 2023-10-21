using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ICollection<Product> Products { get; set; }
        //Bir categorynin birden fazla Productı olabilir dedik.
    }
}
