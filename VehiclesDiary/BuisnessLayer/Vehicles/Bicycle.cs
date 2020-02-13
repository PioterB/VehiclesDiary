namespace VehiclesDiary.BuisnessLayer.Vehicles
{
	public class Bicycle : Vehicle
	{
		public Bicycle(string name, WheelSize wheel) : base(name)
		{
		}
	}

	public enum WheelSize
	{
		Size16,
		Size26,
		Size29,
		Size27_5,
	}
}