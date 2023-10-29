using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NLayer.Core.DTOs
{
    //Bu konu çok oturmadı ??
    public class CustomResponseDto<T>
    {
      
        //Clientlara Data ve Errors kısımlarını dönüyorum.(Status Code dönmüyorum.)
        public  T Data { get; set; }
        /// <summary>
        ///Ben bu status code'ları dış dünyaya açmak istemiyorum. Kısacası clientlara bu status codeları göterilmesini istemmediğim de kullanılır.
        ///Bir istek yapıldığında normal de durum kodu döner body alanında (200,404 gibi) fakat biz bunu istemediğimizden JsınIgnore kullanırız.
        /// Status code 200-404-201 giib response ile dönen e hata olduğunda farketmemizi sağlayan kodlar.
        /// </summary>
        [JsonIgnore]
        public  int StatusCode { get; set; }
        public  List<string> Errors { get; set; }  //Hataları tutuyoruz.

        //Property sonu

        //return ederken method ismi yazılır mı ? Bakmalısın. (

        /// <summary>,
        ///Bu yapılara Static Factory Method denir.  Factory Design Pattern'dan gelir.
        ///Burada static methodlar tanımlayarak success ve fail olduğunda yazacağı şeyleri bbelirtiyoruz.
        /// </summary>
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            return new  CustomResponseDto<T>{ StatusCode = statusCode, Errors = new List<string> { errors }};
        }

    }
}
