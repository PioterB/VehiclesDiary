using System;
using TestDataGenerators;
using VehiclesDiary.Services;

namespace VehicleDiary.DataGenerators
{
	public class VehicleCreationRequestGenerator
	{
		public VehicleCreationRequest Create()
		{
			return new VehicleCreationRequest() {Name = StringGenerator.Create()};
		}
	}
}
