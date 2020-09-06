using System;
using System.Linq;
using TaskParallelLibExample.ForLoop;

namespace TaskParallelLibExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParallelForLoop.BasicParallelForLoop();

            //ParalllelForEachLoop.BasicParallelForEach();

            //CancelLoops.BasicCancelLoop();

            ExceptionHandling.Handle();
            Console.ReadLine();
        }

        
    }
}
