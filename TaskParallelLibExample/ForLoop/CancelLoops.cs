using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibExample.ForLoop
{
    public static class CancelLoops
    {
        public static void BasicCancelLoop()
        {
            int[] nums = Enumerable.Range(0, 100000).ToArray();
            CancellationTokenSource cts = new CancellationTokenSource();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cts.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            Console.WriteLine("Press any key to start. Press 's' to cancel.");
            Console.ReadKey();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 's')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                Parallel.ForEach(nums, parallelOptions, (num) =>
                {
                    Console.WriteLine("{0} on {1}", num, Thread.CurrentThread.ManagedThreadId);
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }
        }
    }
}
