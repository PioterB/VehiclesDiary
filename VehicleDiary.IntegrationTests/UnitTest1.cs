using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleDiary.DataGenerators;
using VehiclesDiary.BusinessLayer.Events;
using VehiclesDiary.BusinessLayer.Vehicles;
using VehiclesDiary.DataAccess;
using VehiclesDiary.Services;

namespace VehicleDiary.IntegrationTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Vehicles_NewCar_Created()
		{
			//IRepository<Vehicle> readRepo = new Repository<Vehicle>();
			//IRepository<DiaryEvent> eventRepo = new Repository<DiaryEvent>();
			//IVehiclesManager menago = new VehiclesManager(readRepo, eventRepo);
			//var unitUnderTests = new VehiclesController(menago, readRepo);

			//unitUnderTests.Add(new VehicleGenerator().Create());


		}
	}
}
