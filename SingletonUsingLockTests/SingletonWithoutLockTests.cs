using Patterns;
namespace SingletonTests
{
	[TestFixture]
	public class SingletonWithoutLockTests
	{
		[Test]
		public void Singleton_Returns_Same_Instance()
		{
			var instance1 = SingletonWithoutLock.Instance;
			var instance2 = SingletonWithoutLock.Instance;

			Assert.That(instance2, Is.SameAs(instance1));
		}

		[Test]
		public void Singleton_Creates_Only_One_Instance_Multithreaded()
		{
			SingletonWithoutLock? firstInstance = null;
			SingletonWithoutLock? secondInstance = null;
			var thread1 = new Thread(() =>
			{
				firstInstance = SingletonWithoutLock.Instance;
			});
			var thread2 = new Thread(() =>
			{
				secondInstance = SingletonWithoutLock.Instance;
			});

			thread1.Start();
			thread2.Start();
			thread1.Join();
			thread2.Join();

			Assert.That(secondInstance, Is.SameAs(firstInstance));
		}
	}
}
