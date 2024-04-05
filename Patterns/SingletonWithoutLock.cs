namespace Patterns
{
	public sealed class SingletonWithoutLock
	{
		private static readonly SingletonWithoutLock instance = new();
		static SingletonWithoutLock() { }

		private SingletonWithoutLock() { }

		public static SingletonWithoutLock Instance { get {  return instance; } }
	}
}
