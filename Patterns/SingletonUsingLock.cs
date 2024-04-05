namespace Patterns
{
	public class SingletonUsingLock
	{
		private static SingletonUsingLock? instance;
		private static readonly object lockThread = new();

		private SingletonUsingLock() { }
		public static SingletonUsingLock Instance
		{
			get
			{
				lock (lockThread)
				{
					instance ??= new SingletonUsingLock();
					return instance;
				}				
			}
		}
	}
}
