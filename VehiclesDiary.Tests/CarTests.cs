using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class CarTests
	{
		private Car _unitUnderTest;

		[TestInitialize]
		public void TestInitialize()
		{
			_unitUnderTest = new Car(StringGenerator.Create(), RegistrationPlate.Empty);
		}

		[TestMethod]
		public void ChangePlate_Plate_Changed()
		{
			var car = new VehicleGenerator().CreateCar();
			var newPlate = RegistrationPlate.Empty;

			car.ChangePlate(newPlate);

			Assert.AreEqual(newPlate, car.Plate);
		}

		[TestMethod]
		[ExpectedException(typeof(UpdateFailedException))]
		public void ChangePlate_Nothing_Changed()
		{
			var car = new VehicleGenerator().CreateCar();

			car.ChangePlate(null);

			Assert.IsTrue(false, "Exception should be throwned");
		}
	}
}
