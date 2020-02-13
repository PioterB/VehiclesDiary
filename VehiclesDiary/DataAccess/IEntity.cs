namespace VehiclesDiary.DataAccess
{
	public interface IEntity<TKey>
	{
		TKey Key { get; }
	}
}