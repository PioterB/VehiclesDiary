using System.Linq;

namespace VehiclesDiary.BusinessLayer.Vehicles
{
	public class RegistrationPlate
	{
		public static RegistrationPlate Empty => new RegistrationPlate("W0 00000");

		public RegistrationPlate(string value)
		{
			ValidatePlate(value);

			Value = value;
		}

		public string Value { get; }


		private void ValidatePlate(string plate)
		{
			if (StartWithLetter(plate) == false)
			{
				throw new UpdateFailedException("must begin with voivodship code");
			}

			if (EnsureCorrectLength(plate) == false)
			{
				throw new UpdateFailedException("must begin with voivodship code");
			}
		}

		private bool EnsureCorrectLength(string newPlate)
		{
			return newPlate.Length >= 5 && newPlate.Length <= 8; // W0 000
		}

		private bool StartWithLetter(string plate)
		{
			return char.IsLetter(plate.First());
		}
	}
}