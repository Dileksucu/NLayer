using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductService:IService<Product>
    {
        /// <summary>
        /// Burada Product parametresini kullanmıcam , özelleştirilmiş bir Dto kullanıcam.
        /// ProductWithCategoryDto sınıfında , ProductDto'yu kalıttım ve 
        /// içine CategoryDto'daki property gelmesi için onun propertysini tanımladım.
        /// </summary>
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
        //Direkt içerisinde CustomResponseDto döndük bu sayede istenen datayı dönüyorum.
    }
}
