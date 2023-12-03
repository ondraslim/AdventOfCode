namespace AdventOfCode.Helpers;

public static class CollectionsExtensions
{
    public static bool IsIndexValid<T>(
        this ICollection<T> collection,
        int index)
    {
        return 0 <= index && index < collection.Count;
    }
    public static bool IsIndexValid(
        this string text,
        int index)
    {
        return 0 <= index && index < text.Length;
    }

    public static bool ContainsKey<T>(
        this IDictionary<string, T> dictionary, 
        ReadOnlySpan<char> key)
        => dictionary.TryGetKey(key, out _);

    public static bool TryGetKey<T>(
        this IDictionary<string, T> dictionary,
        ReadOnlySpan<char> key,
        out string? foundKey)
    {
        foreach (var dictionaryKey in dictionary.Keys)
        {
            if (MemoryExtensions.SequenceEqual(key, dictionaryKey))
            {
                foundKey = dictionaryKey;
                return true;
            }
        }

        foundKey = null;
        return false;
    }

    public static bool TryGetValue<T>(
        this IDictionary<string, T> dictionary,
        ReadOnlySpan<char> key,
        out T? value)
    {
        if (dictionary.TryGetKey(key, out var foundKey))
        {
            value = dictionary[foundKey!];
            return true;
        }

        value = default;
        return false;
    }

    public static bool TryGetValue(
        this ICollection<string> collection,
        ReadOnlySpan<char> value,
        out string? foundValue)
    {
        foreach (var collectionValue in collection)
        {
            if (MemoryExtensions.SequenceEqual(value, collectionValue))
            {
                foundValue = collectionValue;
                return true;
            }
        }

        foundValue = null;
        return false;
    }
}