using VehiclesDiary.BusinessLayer.Vehicles;
using VehiclesDiary.DataAccess;

namespace VehiclesDiary.BusinessLayer.Events
{
	public class DiaryEvent : IEntity<string>
	{
		public DiaryEvent(string key, Vehicle vehicle)
		{
			Key = key;
			Vehicle = vehicle;
		}

		public Vehicle Vehicle { get; }

		public string Key { get; }
	}
}