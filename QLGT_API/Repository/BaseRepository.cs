﻿using QLGT_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected QLGTDBContext context { get; set; }

        public BaseRepository(QLGTDBContext context)
        {
            this.context = context;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public List<T> GetList(int? pageIndex, int? pageSize, Expression<Func<T, bool>> expression)
        {
            var count = context.Set<T>().Count(expression);
            List<T> Data;
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                Data = context.Set<T>().Where(expression).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();
            }
            else
            {
                Data = context.Set<T>().Where(expression).ToList();
            }
            return  Data;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

    }
}
