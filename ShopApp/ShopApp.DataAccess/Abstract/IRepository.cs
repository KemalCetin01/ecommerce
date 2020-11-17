using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
   public interface IRepository <T>
    { //generic yapı
        T GetById(int id);
        T getOne(Expression<Func<T, bool>> filter);

       // IEnumerable<T> getAll(Expression<Func<T, bool>> filter=null);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
