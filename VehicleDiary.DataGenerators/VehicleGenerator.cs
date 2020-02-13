using System;
using TestDataGenerators;
using VehiclesDiary.BuisnessLayer;
using VehiclesDiary.BuisnessLayer.Vehicles;

namespace VehicleDiary.DataGenerators
{
	public class VehicleGenerator
	{
		/// <summary>
		/// Returns avny Vehicle just to satisfy presence is tests. 
		/// </summary>
		/// <param name="name">optional name, when given will be used</param>
		/// <returns>Vehicle instance.</returns>
		public Vehicle Create(string name = null)
		{
			return new Car(name ?? StringGenerator.Create(5), RegistrationPlate.Empty);
		}

		/// <summary>
		/// Returns a <see cref="Bicycle"/> just to satisfy presence is tests. 
		/// </summary>
		/// <returns></returns>
		public Bicycle CreateBicycle(string name = null)
		{
			return new Bicycle(name ?? StringGenerator.Create(5), WheelSize.Size26);
		}

		/// <summary>
		/// Returns a <see cref="Car"/> just to satisfy presence is tests. 
		/// </summary>
		/// <returns></returns>
		public Car CreateCar()
		{
			return new Car(StringGenerator.Create(5), RegistrationPlate.Empty);
		}
	}
}
