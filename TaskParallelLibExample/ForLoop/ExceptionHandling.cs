using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelLibExample.ForLoop
{
    public static class ExceptionHandling
    {
        public static void Handle()
        {
            int[] data = new int[3] { 1, 2, 3 };
            try
            {
                ProcessDataInParallel(data);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ProcessDataInParallel(int[] data)
        {
            Parallel.ForEach(data, d =>
            {
                throw new ArgumentException($"Exception with value {d}");
            });
        }
    }
}
