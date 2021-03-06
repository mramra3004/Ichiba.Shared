﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Common.Sort;
using Shared.Dto;

namespace Shared.EF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> GetDbSet();

        Task<QueryResult<T>> QueryAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize,
            Sorts sort = null);

        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);

        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, int take, bool asNoTracking = false);

        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, int take, Expression<Func<T, object>> order, bool asNoTracking = false);

        Task<IList<TType>> GetAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, bool asNoTracking = false)
            where TType : class;

        Task<IList<TType>> GetAsync<TType>(Expression<Func<T, TType>> select, bool asNoTracking = false)
            where TType : class;

        Task<IList<T>> GetAllAsync(bool asNoTracking = false);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);

        Task<TType> GetSingleAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select = null, bool asNoTracking = false)
            where TType : class;

        Task<T> GetByIdAsync(Guid entityId);

        Task<T> GetByIdAsync<TKey>(TKey entityId);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        void AddRange(IEnumerable<T> entities);

        T Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        TKey Delete<TKey>(TKey entityId);

        T Delete(T entity);

        void DeleteMany(IEnumerable<T> entities);

        Task<int> CountAllAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetRandom();
    }
}