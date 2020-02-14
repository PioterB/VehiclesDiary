using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Moq;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.BusinessLayer;
using VehiclesDiary.BusinessLayer.Vehicles;
using VehiclesDiary.DataAccess;
using VehiclesDiary.Services;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class VehiclesControllerTests
	{
		private VehiclesController _unitUnderTests;
		private static VehicleCreationRequestGenerator _vehiclesGenerator;

		[ClassInitialize]
		public static void OneTimeSetup(TestContext cts)
		{
			_vehiclesGenerator = new VehicleCreationRequestGenerator();
		}

		[TestInitialize]
		public void BeforeEachTest()
		{
			var vehiclesManager = new Mock<IVehiclesManager>();
			var vehiclesRepository = new Mock<IReadRepository<Vehicle>>();
			_unitUnderTests = new VehiclesController(vehiclesManager.Object, vehiclesRepository.Object);
		}

		[TestMethod]
		public void Add_MissingName_Rejected()
		{
			var input = _vehiclesGenerator.Create();
			input.Name = null;

			var result = _unitUnderTests.Add(input);

			Assert.IsNotNull(result, "creation result is missing");
			Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode, "Item without obligatory name was added, when shouldn't");
		}

		[TestMethod]
		public void Del_ExistingItem_Removed()
		{
			var nameToDelete = "toDeleteName";
			var request = new VehicleCreationRequest() { Name = nameToDelete };
			_unitUnderTests.Add(request);

			var result = _unitUnderTests.Del(nameToDelete);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode, "Success was not reported");
		}

		[TestMethod]
		public void Del_NotexistingItem_Removed()
		{
			var nameToDelete = StringGenerator.Create();

			var result = _unitUnderTests.Del(nameToDelete);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode, "Success was not reported");
		}

		[TestMethod]
		public void Mod()
		{
			throw new NotImplementedException("Controller not exists, do codding");
		}
	}
}
