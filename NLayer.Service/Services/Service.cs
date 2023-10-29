using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.SoftDelete;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repository;
using NLayer.Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///Burada veritabanında yani repository katmanındaki oluşturduğumuz methodları
        ///çağırdığımız da değişikleri Vtnına kaydetmek için SaveChange ya da asekron halini çağırmalıyız.
        /// </summary>
        public async Task<T> AddAsycn(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsycn(); //SaveChangeAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsycn(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsycn(); //SaveChangeAsync();
            return entities;
        }

        /// <summary>
        /// //Burada kontrol yapıyoruz ondan CommitAsycn() demek gerekmez.
        /// </summary>
        public async Task<bool> AnyAsycn(Expression<Func<T, bool>> expression)
        {
             return await _repository.AnyAsync(expression);
        }

        /// <summary>
        ///GetAll methodunda IGenericRep. parametre vermemize gerek yokmuş 
        ///Bu hatayı düzelttim nedeni de Where de dorgulama yapıcaz bu parametre ile 
        ///ondan GetAll da bunu yapmamıza gerek kalmıyor.
        ///</summary>
        public async Task<IEnumerable<T>> GetAllAsycn()
        {
            return await _repository.GetAll().ToListAsync();
            //GetAll ile tüm verileri çektik , bunları listeledik.
            //Bu listeleme ile  veritabanına kayıt işlemi gerçekleşmiş oldu.
        }

        public async Task<T> GetByIdAsycn(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsycn(T entity)
        {
            _repository.Remove(entity); // repo da method asekron değil
            await _unitOfWork.CommitAsycn(); //SaveChangeAsync() yapacağımız için bu asekrondur.
        }

        public async Task RemoveRangeAsycn(IEnumerable<T> entities)
        {
           _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsycn();
        }

        public async Task UpdateAsycn(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsycn();
        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        //public async Task SoftDelete(ISoftDelete delete) 
        //{
        //    var contact= await _repository.
        
        
        //}
    }
}
