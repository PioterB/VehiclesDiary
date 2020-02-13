using System;

namespace VehiclesDiary.Controllers
{
	public class VehicleCreationRequest
	{
		public VehicleCreationRequest()
		{
		}

		public string Make { get; set; }
		public string Model { get; set; }
		public DateTimeOffset Bought { get; set; }
		public string Name { get; set; }
	}
}