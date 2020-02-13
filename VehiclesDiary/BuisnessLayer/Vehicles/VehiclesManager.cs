using System.Linq;
using VehiclesDiary.BuisnessLayer.Events;
using VehiclesDiary.DataAccess;

namespace VehiclesDiary.BuisnessLayer.Vehicles
{
	public class VehiclesManager : IVehiclesManager
	{
		private readonly IRepository<Vehicle> _vehiclesRepository;
		private readonly IRepository<DiaryEvent> _eventsRepository;

		public VehiclesManager(IRepository<Vehicle> vehiclesRepository, IRepository<DiaryEvent> eventsRepository)
		{
			_vehiclesRepository = vehiclesRepository;
			_eventsRepository = eventsRepository;
		}

		public void Create(Vehicle vehicle)
		{
			if (_vehiclesRepository.Get(v => v.Name == vehicle.Name).Any())
			{
				throw new CreationFailedException("duplication");
			}

			_vehiclesRepository.Add(vehicle);
		}

		public void Remove(string name)
		{
			EnsureNotConnectedWithOthers(name);

			_vehiclesRepository.Remove(name);
		}

		private void EnsureNotConnectedWithOthers(string vehicleKey)
		{
			if (HasEvents(vehicleKey))
			{
				throw new IntegrityException();
			}
		}

		private bool HasEvents(string vehicleKey)
		{
			return _eventsRepository.Get(e => e.Vehicle.Equals(vehicleKey)).Any();
		}

		public void Update(Vehicle vehicle, string newName)
		{
			vehicle.UpdateName(newName);
		}
	}
}