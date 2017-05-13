using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typing_analist.Time
{
    class Time : ITime
    {
        public ITime Elapsed(Stopwatch to)
        {
            throw new NotImplementedException();
            //Stopwatch start = new Stopwatch();
            //var e = start.ElapsedMilliseconds;
            //Console.WriteLine(e);
            ////int counter = 0;

            //Parallel.ForEach(full_text, (current_string) =>
            //{
            //    Console.Write(current_string);
            //    Interlocked.Increment(ref counter);
            //    if(counter % 3 == 0)
            //        Console.WriteLine();
            ////});
            //full_text.ForEach(Console.WriteLine);
            //Console.WriteLine(System.Diagnostics.Stopwatch.IsHighResolution);
        }

        public ITime Elapsed(Stopwatch from, Stopwatch to)
        {
            throw new NotImplementedException();
        }
    }
}
