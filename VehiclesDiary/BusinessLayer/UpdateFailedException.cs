using System;

namespace VehiclesDiary.BusinessLayer
{
	public class UpdateFailedException : Exception
	{
		public UpdateFailedException(string message) : base(message)
		{
		}
	}
}