using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace VehiclesDiary.DataAccess
{
	internal class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity<string>
	{
		private readonly ICollection<TEntity> _memory;

		[ExcludeFromCodeCoverage]
		public Repository()
		{
			_memory = InitializeMemory();
		}

		[ExcludeFromCodeCoverage]
		public void Add(TEntity item)
		{
			_memory.Add(item);
		}

		public IEnumerable<TEntity> Get(Func<TEntity, bool> filter = null)
		{
			return filter == null ? _memory.ToArray() : _memory.Where(filter).ToArray();
		}

		public void Remove(string key)
		{
			_memory.Remove(_memory.FirstOrDefault(i => i.Key == key));
		}

		[ExcludeFromCodeCoverage]
		protected virtual ICollection<TEntity> InitializeMemory()
		{
			return new List<TEntity>();
		}
	}
}