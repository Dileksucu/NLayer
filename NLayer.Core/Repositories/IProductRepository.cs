using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //Generic Repositoryden gelen methodlar ile burada tanımladığım meyhod olacak.
        Task<List<Product>> GetProductWithCategory();
    }
}
