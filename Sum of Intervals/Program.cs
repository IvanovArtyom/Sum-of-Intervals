using System;
using System.Linq;
using System.Collections.Generic;

public class Intervals
{
    public static void Main()
    {
        // Test
        var t = SumIntervals(new (int, int)[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) });
        // ...should return 19
    }

    public static int SumIntervals((int, int)[] intervals)
    {
        var completeIntervals = new List<(int, int)>();

        foreach (var interval in intervals.OrderBy(x => x.Item1).ToArray())
        {
            if (interval.Item1 == interval.Item2)
                continue;

            if (completeIntervals.Count == 0)
                completeIntervals.Add(interval);

            else if (interval.Item1 <= completeIntervals[^1].Item2)
                completeIntervals[^1] = new(completeIntervals[^1].Item1, Math.Max(completeIntervals[^1].Item2, interval.Item2));

            else completeIntervals.Add(interval);
        }

        return completeIntervals.Sum(x => x.Item2 - x.Item1);
    }
}