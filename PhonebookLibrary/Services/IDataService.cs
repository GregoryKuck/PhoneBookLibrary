using PhonebookLibrary.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhonebookLibrary.Services
{
    public interface IDataService<TEntity> where TEntity : class, IIdentifiable
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<ICollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> match);
        Task<TEntity> Add(TEntity t);
    }
}
