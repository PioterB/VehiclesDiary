using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VehiclesDiary.Tests
{
	public static class ObjectExtensions
	{
		public static void SetField(this object subject, string fieldName, object value)
		{
			subject.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(subject, value);
		}
	}
}
