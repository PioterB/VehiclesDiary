using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesDiary.Controllers
{
	public class VehiclesManager
	{
		private ICollection<Vehicle> _vehicles = new List<Vehicle>();

		public void Create(Vehicle vehicle)
		{
			if (_vehicles.FirstOrDefault(v => v.Name == vehicle.Name) != null)
			{
				throw new CreationFailedException("duplication");
			}

			_vehicles.Add(vehicle);
		}

		internal void Remove(string name)
		{
			var item = _vehicles.FirstOrDefault(v => v.Name == name);
			_vehicles.Remove(item);
		}

		public void Update(Vehicle vehicle, string newName)
		{
			vehicle.UpdateName(newName);
		}
	}
}