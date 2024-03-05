using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.Abstractions.IBaseRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        public string Create (T model);
        public IEnumerable<T> GetAll ();
        public T GetByAny (Expression<Func<T, bool>> expression);
        public string Update (T model); 
        public string Delete (Expression<Func<T, bool>> expression);
    }
}
