using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibExample.ForLoop
{
    public static class ParallelForLoop
    {
        public static void BasicParallelForLoop()
        {
            long totalSize = 0;
            Console.WriteLine("Enter valid directory path :");
            String args = Console.ReadLine();

            if (!Directory.Exists(args))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(args);
            Parallel.For(0, files.Length,
                         index => {
                             FileInfo fileInfo = new FileInfo(files[index]);
                             long size = fileInfo.Length;
                             Interlocked.Add(ref totalSize, size);
                         });

            Console.WriteLine("Directory '{0}':, {1:N0} files, {2:N0} bytes", args, files.Length, totalSize);            
        }
    }
}
