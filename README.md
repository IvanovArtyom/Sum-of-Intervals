## Description:

Write a function called ```sumIntervals```/```sum_intervals``` that accepts an array of intervals, and returns the sum of all the interval lengths.
Overlapping intervals should only be counted once.

### Intervals
Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always be less than the second value.
Interval example: ```[1, 5]``` is an interval from ```1``` to ```5```. The length of this interval is ```4```.

### Overlapping Intervals
List containing overlapping intervals:
```C#
[
   [1, 4],
   [7, 10],
   [3, 5]
]
```
The sum of the lengths of these intervals is ```7```. Since ```[1, 4]``` and ```[3, 5]``` overlap, we can treat the interval as ```[1, 5]```, which has a length of ```4```.

### Examples:
```C#
sumIntervals( [
   [1, 2],
   [6, 10],
   [11, 15]
] ) => 9

sumIntervals( [
   [1, 4],
   [7, 10],
   [3, 5]
] ) => 7

sumIntervals( [
   [1, 5],
   [10, 20],
   [1, 6],
   [16, 19],
   [5, 11]
] ) => 19

sumIntervals( [
   [0, 20],
   [-100000000, 10],
   [30, 40]
] ) => 100000030
```
### Tests with large intervals
Your algorithm should be able to handle large intervals. All tested intervals are subsets of the range ```[-1000000000, 1000000000]```.
### My solution
```C#
using System;
using System.Linq;
using System.Collections.Generic;

public class Intervals
{
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
            {
                completeIntervals[^1] = new(completeIntervals[^1].Item1,
                   Math.Max(completeIntervals[^1].Item2, interval.Item2));
            }

            else completeIntervals.Add(interval);
        }

        return completeIntervals.Sum(x => x.Item2 - x.Item1);
    }
}
```
