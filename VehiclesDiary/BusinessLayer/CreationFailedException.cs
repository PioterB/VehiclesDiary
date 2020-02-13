using System;

namespace VehiclesDiary.BusinessLayer
{
	public class CreationFailedException : Exception
	{
		public CreationFailedException(string message) : base(message)
		{
		}
	}
}