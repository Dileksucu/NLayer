using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Core.SoftDelete;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseContoller
    {
        /// <summary>
        ///Controller'a temiz tutmak önemli , içerisinde validation gibi ya da farklı işlemler yapmıcam.
        ///Mappleme olayını burada gerçekleştiricem fakat
        ///İlerideki dersler de custom repositoryler (product service gibi ) oluşturduğumuz da mappleme olayını service katmanında yapıcaz.
        ///Generic repository kullandığımız  için şu an mapplemeyi burada yapıcam. 
        /// </summary>
        private readonly IMapper _mapper; //Mappleme yapıldı . Burada hazır ınterface kullandık.
        private readonly IService<Product> _service;
        private readonly IProductService _productService;
        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        ///GET api/products/GetProductWithCategory olarak çağırıcaz, nedeni ;
        ///method ismi Get ile başlayan iki method olduğundan çakışma olmasın diye bu şekilde belirtiyoruz.
        /// </summary>
        
        //GET api/products/GetProductWithCategory
        [HttpGet("[action]")] //--> action yazarsak direkt method ismini alır.
        public async Task<IActionResult> GetProductWithCategory() 
        {
            return CreateActionResult(await _productService.GetProductWithCategory());
            //Service katmanında methoda yazdığımız kodları döner.
        }

        ///<summary>
        ///Bütün datayı alıcam bu controller ile
        ///</summary>
        
        //GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await _service.GetAllAsycn(); // entity dönüyor o  yüzden mappleme yapmam gerekir.
            var productMapp = _mapper.Map<List<ProductDto>>(result.ToList()); //entity'i Dto'ya mappledik. 
            return Ok(productMapp);
            //return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productMapp)); 
            //Bu yazım şekli çok karışık ve clean kod olmadığından ben bu işlemi yapıcak bir BaseController oluşturayım.
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productDto)); kısmı aşadaki controller içine yazıcam.
        }

        //GET api/products/5 
        [HttpGet("{id}")] //Eğer ben parametresini yani id'yi belirtmezsem bu kısmı QueryString'den bekler.
        public async Task<IActionResult> GetById(int id) 
        {
            var result= await _service.GetByIdAsycn(id); //Girilen id ile tablodaki veriyi eşleştiriyoruz.
            var productMapp =  _mapper.Map<ProductDto>(result); //eşleştirdiğimiz id'ye göre product'ı ProductDto'ya mappliyoruz.
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(204, productMapp));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product) 
        {
            var result = await _service.AddAsycn(_mapper.Map<Product>(product)); //Product'ı Product dto ya çevirdim.
            var productMapp = _mapper.Map<ProductDto>(result);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201,productMapp));
            //201 status code - created 
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            //geriye bir şey dönmediği için bu yazdığımı değişkene atıp , mapping yapmama gerek yok.
            await _service.UpdateAsycn( _mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<CustomNoContentDto>.Success(204));
            //204 status code - No content (geriye dönüş baaşrılı fakat boş satır döner , geriye bir veri dönmediğin de kullanırız.) 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id) 
        {
            var result = await _service.GetByIdAsycn(id);
            await _service.RemoveAsycn(result);
            return CreateActionResult(CustomResponseDto<CustomNoContentDto>.Success(204));
            //204 status code - No content
        }
    }

}
