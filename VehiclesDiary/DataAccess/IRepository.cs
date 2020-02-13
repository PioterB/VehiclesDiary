﻿using System;
using System.Collections.Generic;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.DataAccess
{
	public interface IRepository<TEntity>
	{
		void Add(TEntity vehicle);

		IEnumerable<TEntity> Get(Func<TEntity, bool> filter);

		void Remove(string key);
	}
}