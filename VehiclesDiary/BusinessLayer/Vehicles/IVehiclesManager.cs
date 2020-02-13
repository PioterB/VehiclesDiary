namespace VehiclesDiary.BusinessLayer.Vehicles
{
	public interface IVehiclesManager
	{
		void Create(Vehicle vehicle);

		void Remove(string name);

		void Update(Vehicle vehicle, string newName);
	}
}