using System;
using VehiclesDiary.DataAccess;

namespace VehiclesDiary.BusinessLayer.Vehicles
{
	public abstract class Vehicle : IEquatable<Vehicle>, IEquatable<string>, IEntity<string>
	{
		protected Vehicle(string name)
		{
			Name = name;
		}

		public string Name { get; private set; }
		
		public string Key => Name;

		public bool Equals(Vehicle other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Name == other.Name;
		}

		public bool Equals(string otherKey)
		{
			if (ReferenceEquals(null, otherKey)) return false;
			return Name == otherKey;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Vehicle) obj);
		}

		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}

		public void UpdateName(string newName)
		{
			Name = newName;
		}
	}
}