using Patterns;

namespace SingletonTests
{
	public class SingletonUsingLazyTests
	{
		[Test]
		public void Singleton_Returns_Same_Instance()
		{
			var instance1 = SingletonUsingLazy.Instance;
			var instance2 = SingletonUsingLazy.Instance;

			Assert.That(instance2, Is.SameAs(instance1));
		}

		[Test]
		public void Singleton_Creates_Only_One_Instance_Multithreaded()
		{
			SingletonUsingLazy? firstInstance = null;
			SingletonUsingLazy? secondInstance = null;
			var thread1 = new Thread(() =>
			{
				firstInstance = SingletonUsingLazy.Instance;
			});
			var thread2 = new Thread(() =>
			{
				secondInstance = SingletonUsingLazy.Instance;
			});

			thread1.Start();
			thread2.Start();
			thread1.Join();
			thread2.Join();

			Assert.That(secondInstance, Is.SameAs(firstInstance));
		}
	}
}
