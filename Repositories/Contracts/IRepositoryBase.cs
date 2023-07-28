﻿using System;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
	public interface IRepositoryBase<T>
	{
		IQueryable<T> FindAll(bool changeTracker);
		IQueryable<T> FindByCondition( Expression<Func<T,bool>> expression  ,bool changeTracker);
		void Create(T entity);
		void Update(T entity);
        void Delete(T entity);

    }
}

