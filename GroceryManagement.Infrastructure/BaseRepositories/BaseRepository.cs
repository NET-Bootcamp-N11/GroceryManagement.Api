using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Application.Abstractions.IBaseRepositories;
using GroceryManagement.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.Infrastructure.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly GroceryManagementDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(GroceryManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public string Create(T model)
        {
            _dbSet.AddAsync(model).GetAwaiter().GetResult();
            _context.SaveChangesAsync().GetAwaiter().GetResult();
            return "Create qilindi";
        }

        public string Delete(Expression<Func<T, bool>> expression)
        {
            T model = _dbSet.FirstOrDefaultAsync(expression).GetAwaiter().GetResult();
            if (model == null)
            {
                return "Ma'lumot topilmadi";
            }
            _dbSet.Remove(model);
            _context.SaveChangesAsync().GetAwaiter().GetResult();

            return "Ma'lumot o'chirildi";
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> Data = _dbSet.ToListAsync().GetAwaiter().GetResult();
            return Data;
        }

        public T GetByAny(Expression<Func<T, bool>> expression)
        {
            T Data = _dbSet.FirstOrDefault(expression)!;
            return Data;
        }

        public string Update(T model)
        {
            _dbSet.Update(model);
            _context.SaveChangesAsync().GetAwaiter().GetResult();
            return "Update qilindi";
        }
    }
}
