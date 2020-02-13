using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.BusinessLayer;
using VehiclesDiary.BusinessLayer.Events;
using VehiclesDiary.BusinessLayer.Vehicles;
using VehiclesDiary.DataAccess;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class VehicleManagerTests
	{
		private VehiclesManager _unitUnderTests;
		private Mock<IRepository<Vehicle>> _vehicleRepository;
		private Mock<IRepository<DiaryEvent>> _eventsRepository;

		[TestInitialize]
		public void BeforeEachTest()
		{
			_vehicleRepository = new Mock<IRepository<Vehicle>>();
			_eventsRepository = new Mock<IRepository<DiaryEvent>>();
			_unitUnderTests = new VehiclesManager(_vehicleRepository.Object, _eventsRepository.Object);
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
			// arrange
			var input = new VehicleGenerator().Create();
			_vehicleRepository.Setup(r => r.Get(It.IsAny<Func<Vehicle, bool>>())).Returns(new[] {input});

			//act
			_unitUnderTests.Create(input);

			// assert
			Assert.IsTrue(false, "exception was expected, shouldn't hit here");

		}

		[TestMethod]
		public void Create_Bicycle_Added()
		{
			var input = new VehicleGenerator().CreateBicycle();

			_unitUnderTests.Create(input);

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void Update_UniqueName_Changed()
		{
			var input = new VehicleGenerator().CreateBicycle();
			var newName = StringGenerator.Create(4);
			_unitUnderTests.Update(input, newName);

			Assert.AreEqual(newName, input.Name);
		}

		[TestMethod]
		public void Remove_NoEvents_Removed()
		{
			var vehicle = new VehicleGenerator().Create();

			_unitUnderTests.Remove(vehicle.Name);

			_vehicleRepository.Verify(r => r.Remove(vehicle.Name), Times.Once);
		}

		[TestMethod]
		[ExpectedException(typeof(IntegrityException), "Duplication was not singnaled")]
		public void Remove_HasEvents_Exception()
		{
			var diaryEvent = new DiaryEventsGenerator().Create();
			var vehicle = new VehicleGenerator().Create();
			_eventsRepository.Setup(r => r.Get(It.IsAny<Func<DiaryEvent, bool>>())).Returns(new[] { diaryEvent });

			_unitUnderTests.Remove(vehicle.Name);

			_vehicleRepository.Verify(r => r.Remove(vehicle.Name), Times.Never);
		}
	}
}
