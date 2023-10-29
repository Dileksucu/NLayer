using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        //TO DO: ProductDto'dan çoğu prop geliyor sadece categoryDto yok burada onu ekledim.
        public CategoryDto Category { get; set; }

    }
}
