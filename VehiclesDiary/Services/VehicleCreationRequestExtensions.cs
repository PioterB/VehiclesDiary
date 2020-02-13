using VehiclesDiary.BusinessLayer.Vehicles;

namespace VehiclesDiary.Services
{
	public static class VehicleCreationRequestExtensions
	{
		public static Vehicle ToModel(this VehicleCreationRequest source)
		{
			return new Car(source.Name, RegistrationPlate.Empty);
		}
	}
}
