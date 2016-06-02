using System;

namespace ConsoleApplication2
{
    public interface IWorker<out TAnimal>
        where TAnimal : Animal
    {
        TAnimal GetAnimal();

        void DoWork();
    }

    public abstract class Worker<TAnimal> : IWorker<TAnimal>
        where TAnimal : Animal
    {
        private readonly TAnimal _animal;

        protected Worker(TAnimal animal)
        {
            _animal = animal;
        }
        public TAnimal GetAnimal()
        {
            return _animal;
        }

        public abstract void DoWork();
    }

    public class CowWorker : Worker<Cow>
    {
        public CowWorker(Cow animal) : base(animal)
        {
        }

        public override void DoWork()
        {
            Console.WriteLine("Cow started working!");
        }
    }

    public class HumanWorker : Worker<Human>
    {
        public HumanWorker(Human animal) : base(animal)
        {
        }

        public override void DoWork()
        {
            Console.WriteLine("Human started working!");
        }
    }
}
