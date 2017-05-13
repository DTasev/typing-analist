using System.Diagnostics;

namespace typing_analist.Time
{
    interface ITime
    {
        // this overload allows to initialise start time in constructor
        ITime Elapsed(Stopwatch to);

        ITime Elapsed(Stopwatch from, Stopwatch to);

    }
}
