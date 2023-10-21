using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// //2 methodu olacak; Bu methodlar DbContext'in SaveChange() ve SaveChangeAsycn() methodlarıdır.
        /// </summary>
        Task CommitAsycn(); //SaveChangeAsycn()
        void Commit();   //SaveChange()
    }
}
