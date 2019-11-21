﻿using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture. Persistence.Shared
{
    public class Repository<T>
        : IRepository<T> where T : class, IEntity
    {
        protected readonly IDatabaseContext _database;

        public Repository(IDatabaseContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(int id)
        {
            return _database.Set<T>()
                .Single(p => p.Id == id);
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }
    }
}
