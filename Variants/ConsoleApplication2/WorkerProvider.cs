namespace ConsoleApplication2
{
    public class WorkerProvider
    {
        public IWorker<Animal> GetWorker(Work work)
        {
            if (work.WorkType == WorkType.CartDragging)
            {
                return new CowWorker(new Cow());
            }

            return new HumanWorker(new Human());
        }
    }
}
