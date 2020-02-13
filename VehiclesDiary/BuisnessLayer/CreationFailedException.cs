using System;

namespace VehiclesDiary.BuisnessLayer
{
	public class CreationFailedException : Exception
	{
		public CreationFailedException(string message) : base(message)
		{
		}
	}
}