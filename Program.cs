using System.Collections.Concurrent;

namespace ScratchAsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                int capturedval = i;
                //int capturedvalue = i;
                CustomThreadPool.QueueUserWorkItem( () =>
                { //delegate is same as () =>
                    Console.WriteLine("my implementation threadpool");
                    Console.WriteLine(capturedval);
                    Thread.Sleep(1000);
                });
                
                /*ThreadPool.QueueUserWorkItem( delegate
                {
                    Console.WriteLine("dotnet threadpool");
                    Console.WriteLine(capturedvalue);
                    Thread.Sleep(1000);
                } );*/
            }
            Console.ReadLine();
        }
    }
    internal static class CustomThreadPool
    {
        //the collection is blocking in nature and queue to store our data
        private static readonly BlockingCollection<Action> s_workItems = new();

        //Encapsulates a method that has no parameters and does not return a value.public delegate void Action();
        public static void QueueUserWorkItem(Action action) => s_workItems.Add(action);

        static CustomThreadPool()
        {
            for (int i = 0; i<Environment.ProcessorCount ; i++)
            {
                Thread threadobj = new Thread(() =>
                {
                    while (true)
                    {
                        Action workItem = s_workItems.Take();
                        workItem();
                    }
                });
                threadobj.IsBackground = true;
                threadobj.Start();
            }
        }
    }
}
