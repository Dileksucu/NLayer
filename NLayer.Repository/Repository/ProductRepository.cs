using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        ///Artık ben ProductRepository üzerinden hem GenricRepository methodlarına 
        ///hem de IProductRep. methodlarına erişebileceğim. 
        ///Sadece IProductRepository kalıtsaydım diğer tüm methodlarla (GenericRep. methdolar da gelirdi) birlikte gellirdi.
        /// </summary>
        public async Task<List<Product>> GetProductWithCategory()
        {
            //TO DO: Eager  Loading --> Dataları çekerken Categories'in de alınmasını istedim. Bu yapıya Eager Loading denir.
            //Aşağıda bu yapıyı kullandım.
            //Lazy Loading --> İhtiyaç olduğunda daha sonra Categories çekilirse bu da lazy loading olur.

            //Burada _context GenericRep.'deki oluşturduğumuz "protected readonly AppDbContext _context;" kısmından gelmektedir.
            return await _context.Products.Include(x=>x.Categories).ToListAsync();

            //Include --> Include metodunu kullanarak sorgumuzu çektiğimizde, bu nesneyi dolduracaktır ve
            //Category bilgisini de kullanmak istersek bu şekilde kullanabiliriz.
        }
    }
}
