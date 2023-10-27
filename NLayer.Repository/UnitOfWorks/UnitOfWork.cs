using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context; //sağdan sola aktarılır.
        }

        /// <summary>
        /// Bu method SaveChanges()'e karşılık gelir.
        /// Result methodunu kullanarak asekron methodu, sekron methoda çevirebiliriz,
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Bu method SaveChangesAsync()'e karşılık gelir.
        /// </summary>
        public async Task CommitAsycn()
        {
            await _context.SaveChangesAsync();
        }
    }
}
