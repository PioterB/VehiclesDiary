using VehiclesDiary.BuisnessLayer.Vehicles;

namespace VehiclesDiary.Services
{
	public static class VehicleCreationRequestExtensions
	{
		public static Vehicle ToModel(this VehicleCreationRequest source)
		{
			return new Car("for now", RegistrationPlate.Empty);
		}
	}
}
