namespace AdventOfCode.Helpers;

public static class MathUtils
{
    public static long Lcm(IEnumerable<long> numbers)
    {
        return numbers.Aggregate(Lcm);
    }

    public static long Lcm(long a, long b)
    {
        return Math.Abs(a * b) / Gcd(a, b);
    }

    public static long Gcd(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }
}