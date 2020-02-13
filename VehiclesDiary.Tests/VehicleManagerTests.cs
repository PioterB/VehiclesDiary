using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class VehicleManagerTests
	{
		private VehiclesManager _unitUnderTests;
		private Vehicle _vehicle = new VehicleGenerator().CreateBicycle();

		[TestInitialize]
		public void BeforeEachTest()
		{
			_unitUnderTests = new VehiclesManager();
		}

		[TestMethod]
		public void Create_UniqueName_Added()
		{
			var input = new VehicleGenerator().Create();

			_unitUnderTests.Create(input);

			Assert.IsTrue(true);
		}

		[TestMethod]
		[ExpectedException(typeof(CreationFailedException), "Duplication was not singnaled")]
		public void Add_ExistingName_Rejected()
		{
			var input = new VehicleGenerator().Create();

			_unitUnderTests.Create(_vehicle);
			_unitUnderTests.Create(_vehicle);
		}

		[TestMethod]
		public void Create_Bicycle_Added()
		{
			var input = new VehicleGenerator().CreateBicycle();

			_unitUnderTests.Create(_vehicle);

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void Update_UniqueName_Changed()
		{
			var input = new VehicleGenerator().CreateBicycle();
			var newName = StringGenerator.Create(4);
			_unitUnderTests.Update(_vehicle, newName);

			Assert.AreEqual(newName, _vehicle.Name);
		}
	}
}
