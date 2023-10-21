using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    //Bütün entitylerin ortak kısımlarıdır bu entity.
    public abstract class BaseEntity
    {
        //Not: Id ismini vermemizin sebebi farklı enttiyler de
        //otomatik olarak PK olarak tanımlanabilmesini sağlamak.
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //Abstract yapmamızın sebebi ; newlemeden kullanmak için abstract kullandık.
        //Bu nesne tipi soyut yapılardır ; ınterfaceler gibi. 
    }
}
