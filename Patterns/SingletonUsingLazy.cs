namespace Patterns
{
	public sealed class SingletonUsingLazy
	{
		private static readonly Lazy<SingletonUsingLazy> instance = new(() => new SingletonUsingLazy());
		private SingletonUsingLazy() { }
		public static SingletonUsingLazy Instance { 
			get 
			{ 
				return instance.Value; 
			}
		}
	}
}
