using MicroRabbit.Domain.Core.Events;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    /*
        // Covariance and contravariance

        // This interface can be implicitly cast to LESS DERIVED (upcasting)
        public interface ICovariant<out T> { }

        // This interface can be implicitly cast to MORE DERIVED (downcasting)
        public interface IContravariant<in T> { }

        public class Covariant<T> : ICovariant<T> { }
        public class Contravariant<T> : IContravariant<T> { }

        public class Fruit { }
        public class Apple : Fruit { }

        public class Program
        {
	        public static void Main()
	        {
		        // apple is being upcasted to fruit, without the out keyword this will not compile
		        ICovariant<Fruit> fruit = new Covariant<Apple>();

		        // fruit is being downcasted to apple, without the in keyword this will not compile
		        IContravariant<Apple> apple = new Contravariant<Fruit>();
	        }
        }
    */

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
