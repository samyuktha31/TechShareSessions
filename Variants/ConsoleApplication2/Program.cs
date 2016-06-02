using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cow = new Cow();
            var animalCasted = (Animal) cow;

            var human = new Human();
            var humanCasted = (Animal) human;

            //var cowList = new List<Cow>();
            //var cowListCasted = (List<Animal>) cowList;

            var work = new Work {WorkType = WorkType.WriteCode};

            var worker = new WorkerProvider().GetWorker(work);
            worker.DoWork();

            work = new Work { WorkType = WorkType.CartDragging };

            worker = new WorkerProvider().GetWorker(work);
            worker.DoWork();

            Console.ReadLine();
        }
    }
}
