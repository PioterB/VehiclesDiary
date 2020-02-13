using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesDiary.Controllers
{
	public static class VehicleCreationRequestExtensions
	{
		public static Vehicle ToModel(this VehicleCreationRequest source)
		{
			return new Car("for now", RegistrationPlate.Empty);
		}
	}
}
