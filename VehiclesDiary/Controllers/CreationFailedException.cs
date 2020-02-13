using System;

namespace VehiclesDiary.Controllers
{
	public class CreationFailedException : Exception
	{
		public CreationFailedException(string message) : base(message)
		{
		}
	}
}