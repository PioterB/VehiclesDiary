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
	public class RegistrationPlateTests
	{
		[TestMethod]
		[ExpectedException(typeof(UpdateFailedException))]
		public void ChangePlate_InvalidVoivodoshipCode_Exception()
		{
			new RegistrationPlate("5o ooo");

			Assert.IsTrue(false, "Exception should be throwned");
		}

		[TestMethod]
		public void ChangePlate_CorrectLength_Changed()
		{
			var plate = "A" + StringGenerator.Create(6);

			var newPlate = new RegistrationPlate(plate);

			Assert.AreEqual(plate, newPlate.Value);
		}

		[TestMethod]
		[ExpectedException(typeof(UpdateFailedException))]
		public void ChangePlate_TooShortLength_Exception()
		{
			new RegistrationPlate("5L");

			Assert.IsTrue(false, "Exception should be throwned");
		}

		[TestMethod]
		[ExpectedException(typeof(UpdateFailedException))]
		public void ChangePlate_TooLongLength_Exception()
		{
			new RegistrationPlate("A" + StringGenerator.Create(10));

			Assert.IsTrue(false, "Exception should be throwned");
		}
	}
}
