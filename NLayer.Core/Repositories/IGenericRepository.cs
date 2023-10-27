using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        /// <summary>
        ///IQueryable döndüğümüz de yazdığımız sorgular direkt Vtnına gitmez, mutlaka ToList() methodunu çağırmak gerekir.
        ///Döndükten sonra orderby gibi methodlar çağırabilirim filitrelemek için
        ///daha sonra Vtnına gitmesini istediğim de ToList() methodunu çağırarak Vt nına gitmesini sağlayabilirim.
        ///Kısaca: IQueryable da veritabanına direkt sorgu gitmez . Ben istersem eğer bunu sağlarım
        /// </summary>
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        /// <summary>
        ///Burada T --> aşağıdaki x'e denk gelir yani entitye , bool ise o oluşabilecek sonucun dönüşüde bool'e denk gelir.
        ///productRepository.Where(x=>x.id).OrderBy(); --> çağırırsam içerisine LINQ ile sorgular yazarak filitreleme yapabilirim.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        ///IEnumerable: Interfacedir.
        ///Birden fazla ekle durumu olabilir
        /// </summary>
        Task AddAsync(T entity);
        //Uzun süren işlemler olduğu için Asycn methodu vardır.
        void Update(T entity);
        /// <summary>
        ///Asycn olmamasının sebebi ; ef core da bunların asycn karşılığı yok.
        ///Uzun  süren bir işlem olmadığı için Asycn kullanılmıyor. (Update ve Delete)
        ///Asycn methodların amacı , uzun işlemler de threadleri iyi kullanmaktır.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
