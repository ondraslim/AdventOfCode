namespace AdventOfCode.Helpers;

public static class SpanExtensions
{
    public static bool SequenceEqual(this ReadOnlySpan<char> spanValue, string stringValue)
    {
        var stringSpan = stringValue.AsSpan();
        return stringSpan.SequenceEqual(spanValue);
    }

    public static SplitSpanEnumerable SplitFast(this ReadOnlySpan<char> value, ReadOnlySpan<char> split)
    {
        return new SplitSpanEnumerable(value, split);
    }
}

public readonly ref struct SplitSpanEnumerable
{
    private readonly ReadOnlySpan<char> _span;
    private readonly ReadOnlySpan<char> _split;

    public SplitSpanEnumerable(ReadOnlySpan<char> span, ReadOnlySpan<char> split)
    {
        _span = span;
        _split = split;
    }

    public SplitSpanEnumerator GetEnumerator() => new(_span, _split);
}

public ref struct SplitSpanEnumerator
{
    private readonly ReadOnlySpan<char> _span;
    private readonly ReadOnlySpan<char> _split;

    private int _end;
    private Range _range;

    internal SplitSpanEnumerator(ReadOnlySpan<char> span, ReadOnlySpan<char> split)
    {
        _span = span;
        _split = split;
    }

    public ReadOnlySpan<char> Current => _span[_range];

    public bool MoveNext()
    {
        var start = _end;
        if (start >= _span.Length)
        {
            return false;
        }

        var end = _span[start..].IndexOf(_split);
        if (end == -1)
        {
            end = _span.Length;
        }
        else
        {
            end += start;
        }

        _end = end + _split.Length;
        _range = start..end;

        return true;
    }
}