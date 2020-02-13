using System;

namespace VehiclesDiary.Controllers
{
	public class UpdateFailedException : Exception
	{
		public UpdateFailedException(string message) : base(message)
		{
		}
	}
}