using Patterns;
namespace SingletonTests
{
	[TestFixture]
	public class SingletonUsingLockTests
	{
		[Test]
		public void Singleton_Returns_Same_Instance()
		{
			var instance1 = SingletonUsingLock.Instance;
			var instance2 = SingletonUsingLock.Instance;

			Assert.That(instance2, Is.SameAs(instance1));
		}

		[Test]
		public void Singleton_Creates_Only_One_Instance_Multithreaded()
		{
			SingletonUsingLock? firstInstance = null;
			SingletonUsingLock? secondInstance = null;
			var thread1 = new Thread(() =>
			{
				firstInstance = SingletonUsingLock.Instance;
			});
			var thread2 = new Thread(() =>
			{
				secondInstance = SingletonUsingLock.Instance;
			});

			thread1.Start();
			thread2.Start();
			thread1.Join();
			thread2.Join();

			Assert.That(secondInstance, Is.SameAs(firstInstance));
		}
	}
}
