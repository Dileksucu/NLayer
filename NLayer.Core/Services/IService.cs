using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T: class
    {
        /// <summary>
        ///IGenericRepository gibi methodlardan oluşacak
        ///fakat dönüş tipleri farklı olacak .
        /// İleri de product ve category için ınterfaceler oluşturduğumuz da
        ///  bu methodaların dönüş tipleri farklı olacak.
        /// </summary>
        Task<T> GetByIdAsycn(int id);
        /// <summary>
        /// GetAllAsycn(), bütün datayı alıcaz bu method ile.
        /// Bu method expression almıyor çünkü sorgulama yapmayacak.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsycn(); 
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsycn(Expression<Func<T, bool>> expression);
        Task<T> AddAsycn(T entity); //geriye bir şey dönecek bundan Task<T> ekledim.
        Task<IEnumerable<T>> AddRangeAsycn(IEnumerable<T> entities);
        Task UpdateAsycn(T entity);
        Task RemoveAsycn(T entity);
        Task RemoveRangeAsycn(IEnumerable<T> entities);
    }
}

