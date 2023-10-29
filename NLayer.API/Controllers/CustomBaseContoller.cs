using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Service.Mapping;

namespace NLayer.API.Controllers
{
    public class CustomBaseContoller : ControllerBase
    {
        [NonAction] // --> Enpoint olmadığını belirtmek için yazılır.(Get ya da Post olmadığı için bu attirubute kullanmamız gerekir. )
        //Aşağıdaki method bir enpoint(get ya da post işlemi değildir) değil. 
        public IActionResult CreateActionResult<MapProfile>(CustomResponseDto<MapProfile>response) 
        {
            if (response.StatusCode == 204)
            {
                //NoContent ise buraya girer , geri dönecek bir şeyi yoksa
                return new ObjectResult(null)
                { StatusCode = response.StatusCode };

            }
            //değilse bu kısma girip , hangi status kodu verdiyse onu yazar.
            return new ObjectResult(response.StatusCode)
            { StatusCode = response.StatusCode };
        
        }
    }
}
