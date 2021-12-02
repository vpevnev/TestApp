using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestApp.Domain.Abstract
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        TEntity GetById<TId>(TId id);
        Task<TEntity> GetByIdAsync<TId>(TId id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Получает диапазон значений согласно заданному предикату
        /// </summary>
        /// <param name="predicate">Предикат для фильтрации</param>
        /// <returns>Диапазон значений</returns>
        List<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Добавляет и сохраняет диапазон значений
        /// </summary>
        /// <param name="entities">Перечень значений</param>
        void AddRangeBulkAndSave(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
    }
}
