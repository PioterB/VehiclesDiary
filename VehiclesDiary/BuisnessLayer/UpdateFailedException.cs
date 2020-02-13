using System;

namespace VehiclesDiary.BuisnessLayer
{
	public class UpdateFailedException : Exception
	{
		public UpdateFailedException(string message) : base(message)
		{
		}
	}
}