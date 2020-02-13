using System;
using System.Collections.Generic;

namespace VehiclesDiary.DataAccess
{
	public interface IRepository<TEntity> where TEntity : IEntity<string>
	{
		void Add(TEntity vehicle);

		IEnumerable<TEntity> Get(Func<TEntity, bool> filter = null);

		void Remove(string key);
	}
}