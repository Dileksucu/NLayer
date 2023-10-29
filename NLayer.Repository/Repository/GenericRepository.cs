using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Repository.Context;
using System.Linq.Expressions;

namespace NLayer.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        ///Private yapamamın sebebi ; Bu CRUD işlemleri benim product nesnem iin yetmezse farklı sınıflar oluşturmam gerekebilir.
        ///Bundan dolayı bu sınıflar da bu  nesneyi kullanmak için Protected olarak belirliyoruz.
        /// </summary>
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet; //veritabanındaki tabloya karşılık gelir.

        public GenericRepository(AppDbContext context)
        {
            _context = context;  //sağ taraf sol tarafa atanır.
            _dbSet =context.Set<T>();
            //context içinden Set<T> methodu ile dbset gelir.
            //Sadece ctor içinde set ettik ki başka yer de set etmeyelim.
        }

        //EF Core bunları memeory'e kaydediyor bu işlemler ille.

        public async Task AddAsync(T entity)
          => await _dbSet.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities)
          => await _dbSet.AddRangeAsync(entities);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
           => await _dbSet.AnyAsync(expression);

        /// <summary>
        ///Bu kısımda IQueryable kullanmamın sebebi büütn çektiğim datalar da filitreleme(OrderBy,Distinct,GroupBy) yapabilmek içindi.
        /// </summary>
        public IQueryable<T> GetAll()
         => _dbSet.AsNoTracking().AsQueryable();
        /// <summary>
        ///AsNoTracking() --> Burada aldığımız dataları tracking yapmaması için yani memory de bekltmemesi
        ///için NoTracking() methodunu kullanıyoruz; bu sayede daha performanslı olmasını sağlıyorum.
        /// AsQueryable() -->Bu  method ile tüm datayı almak istiyorum.Bu tüm datayı aldığımda da 
        ///dataları memoryde tutmaması  için NoTracking() kullanılır.
        /// </summary>

        public async Task<T> GetByIdAsync(int id) { return await _dbSet.FindAsync(id); }

        /// <summary>
        /// Remove  ve Update methodlarına terkar daha güzel nasıl yazarım diye bakmalısın
        /// </summary>
        public void Remove(T entity)
        => _dbSet.Remove(entity); //Burada uzun bir işlem yapılmadığı için remove methodunun Async yoktur.

        public void RemoveRange(IEnumerable<T> entities)
         => _dbSet.RemoveRange(entities);

        public void Update(T entity)
         =>_dbSet.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression){ return _dbSet.Where(expression); }

    }
}
