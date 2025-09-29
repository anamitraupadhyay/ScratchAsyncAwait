namespace ScratchAsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                int capturedval = i;
                ThreadPool.QueueUserWorkItem(delegate {
                    Console.WriteLine(capturedval);
                    Thread.Sleep(1000);
                });
            }
            Console.ReadLine();
        }
    }
}
