using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile:Profile
    {
        /// <summary>
        /// CreateMap<Product, ProductDto>(); --> Bu sırada Product'ı, ProductDto'ya çevirirsiniz
        /// ReverseMap() methodunu kullanırsak --> tam tersi olur yani ProductDto'u Product'a çevirmiş oluruz.
        /// </summary>
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            //Bu yıkarıdaki işlemler de Dto classlarını , Entity classlarına mappledik.

            CreateMap<ProductUpdateDto, Product>();
            //Update işlemi sırasında ; ProductUpdateDto'yu Product'a çevir dedim.

            CreateMap<Product, ProductWithCategoryDto>();
            //Product'ı , ProductWithCategoryDto'ya dönüştürüyoruz.
        }
    }
}
