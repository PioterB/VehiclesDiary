using System;
using VehiclesDiary.BuisnessLayer;
using VehiclesDiary.BuisnessLayer.Events;

namespace VehiclesDiary.Tests
{
	public class DiaryEventsGenerator
	{
		public DiaryEvent Create()
		{
			return new DiaryEvent();
		}
	}
}