using System;
using TestDataGenerators;
using VehicleDiary.DataGenerators;
using VehiclesDiary.BusinessLayer.Events;

namespace VehiclesDiary.Tests
{
	public class DiaryEventsGenerator
	{
		public DiaryEvent Create()
		{
			return new DiaryEvent(StringGenerator.Create(5), new VehicleGenerator().Create());
		}
	}
}