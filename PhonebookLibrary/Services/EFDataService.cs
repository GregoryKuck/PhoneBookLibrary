using Microsoft.EntityFrameworkCore;
using PhonebookLibrary.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhonebookLibrary.Services
{
    public class EFDataService<TEntity> : IDataService<TEntity> where TEntity : class, IIdentifiable
    {
        private readonly PhonebookContext _db;

        public EFDataService(PhonebookContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _db.Set<TEntity>().Where(t => t.Id == id).SingleOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return await _db.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity t)
        {
            _db.Set<TEntity>().Add(t);
            await _db.SaveChangesAsync();
            return t;
        }
    }
}
