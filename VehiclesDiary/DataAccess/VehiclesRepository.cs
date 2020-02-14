using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VehiclesDiary.BusinessLayer.Vehicles;

namespace VehiclesDiary.DataAccess
{
	internal  class VehiclesRepository : Repository<Vehicle>
	{
		[ExcludeFromCodeCoverage]
		protected override ICollection<Vehicle> InitializeMemory()
		{
			return new List<Vehicle>()
			{
				new Bicycle("Niner", WheelSize.Size29), 
				new Car("Volviak", RegistrationPlate.Empty)
			};
		}
	}
}