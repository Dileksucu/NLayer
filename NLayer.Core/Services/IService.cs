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
        Task<T> GetByAsycn();
        Task<IEnumerable<T>> GetAllAsycn(); //Bütün datayı alıcaz bu metjod ile
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<T> AnyAsycn(Expression<Func<T, bool>> expression);
        Task AddAsycn(T entity);
        Task AddRangeAsycn(IEnumerable<T> entities);
        Task UpdateAsycn(T entity);
        Task RemoveAsycn(T entity);
        Task RemoveRangeAsycn(IEnumerable<T> entities);
    }
}

