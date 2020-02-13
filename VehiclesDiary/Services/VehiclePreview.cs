using System;
using VehiclesDiary.BusinessLayer.Vehicles;

namespace VehiclesDiary.Services
{
	public class VehiclePreview
	{
		public VehiclePreview(Vehicle item)
		{
			Id = item.Key;
			Name = item.Name;
		}

		public string Id { get; set; }

		public string Name { get; set; }
	}
}