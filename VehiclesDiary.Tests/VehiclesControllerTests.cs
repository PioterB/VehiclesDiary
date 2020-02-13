using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.AspNetCore.Http;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class VehiclesControllerTests
	{
		private VehiclesController _unitUnderTests;

		[TestInitialize]
		public void BeforeEachTest()
		{
			var vehiclesManager = new VehiclesManager();
			_unitUnderTests = new VehiclesController(vehiclesManager);
		}

		[TestMethod]
		public void Add_NotexistingName_Added()
		{
			var input = new VehicleCreationRequestGenerator().Create();

			var result = _unitUnderTests.Add(input);

			Assert.IsNotNull(result, "creation result is missing");
			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode, "Positive result was not signalled");
		}

		[TestMethod]
		public void Add_ExistingName_Rejected()
		{
			var input = new VehicleCreationRequestGenerator().Create();

			_unitUnderTests.Add(input);
			var result = _unitUnderTests.Add(input);

			Assert.IsNotNull(result, "creation result is missing");
			Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode, "Duplication was allowed when shouldn't");
		}

		[TestMethod]
		public void Add_MissingName_Rejected()
		{
			var input = new VehicleCreationRequestGenerator().Create();
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
