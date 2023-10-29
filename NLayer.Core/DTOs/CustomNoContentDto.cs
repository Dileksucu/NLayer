using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomNoContentDto
    {
            /// <summary>
            ///Bu kısım da dönüş başarılı olduğu halde Data dönmeyen durumlar olabilir
            ///o durumda geriye hatayı döndürmek istediğimiz için oluşturduk  bu sınıfı   
            /// </summary>
            public  List<string> Errors { get; set; }
            [JsonIgnore]
            public  int StatusCode { get; set; }

        //Biraz daha oturacak bu kısım - karışık ?

        public static CustomNoContentDto Success(int statusCode)
        {
            return new CustomNoContentDto { StatusCode = statusCode };
        }

        public static CustomNoContentDto Fail(int statusCode, List<string> errors)
        {
            return new CustomNoContentDto { StatusCode = statusCode, Errors = errors };
        }

        public static CustomNoContentDto Fail(int statusCode, string errors)
        {
            return new CustomNoContentDto { StatusCode = statusCode, Errors = new List<string> { errors } };
        }


    }
}
