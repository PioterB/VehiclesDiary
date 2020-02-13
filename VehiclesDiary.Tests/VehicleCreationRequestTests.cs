using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
	[TestClass]
	public class VehicleCreationRequestTests
	{
		[TestMethod]
		public void Make_Value_Set()
		{
			var request = new VehicleCreationRequest();
			var value = "Daewoo";

			request.Make = value;

			Assert.AreEqual(value, request.Make);
		}

		[TestMethod]
		public void Model_Value_Set()
		{
			var request = new VehicleCreationRequest();
			var value = "Daewoo";

			request.Model = value;

			Assert.AreEqual(value, request.Model);
		}

		[TestMethod]
		public void Name_Value_Set()
		{
			var request = new VehicleCreationRequest();
			var value = "Daewoo";

			request.Name = value;

			Assert.AreEqual(value, request.Name);
		}

		[TestMethod]
		public void Bought_Value_Set()
		{
			var request = new VehicleCreationRequest();
			var value = new DateTimeOffset(DateTime.Now);

			request.Bought = value;

			Assert.AreEqual(value, request.Bought);
		}
	}
}
