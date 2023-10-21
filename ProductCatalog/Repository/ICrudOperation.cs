using ProductCatalog.Models;
using System.Linq.Expressions;

namespace ProductCatalog.Repository
{
    public interface ICrudOperation<T> where T : class
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        void insert(T Entity);
        void update(T Entity);
        void Delete(int id);
        int save();
       
    }
}
