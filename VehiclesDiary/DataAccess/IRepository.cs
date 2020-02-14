using System;
using System.Collections.Generic;

namespace VehiclesDiary.DataAccess
{
	public interface IReadRepository<TEntity> where TEntity : IEntity<string>
	{
		IEnumerable<TEntity> Get(Func<TEntity, bool> filter = null);
	}

	public interface IRepository<TEntity> : IReadRepository<TEntity> where TEntity : IEntity<string>
	{
		void Add(TEntity vehicle);

		void Remove(string key);
	}
}