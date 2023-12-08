using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day04;

public class PartOneAndTwo
{
    public int RunPartOne(string[] cards)
    {
        return cards.Select(CalculateScore).Sum();
    }

    public int RunPartTwo(string[] cards)
    { 
        var cardCopies = cards.Select(c => (Card: c, CopyCount: 1)).ToList();
        
        for (var i = 0; i < cardCopies.Count; i++)
        {
            var (currentCard, currentCardCopies) = cardCopies[i];
            var matchCount = CalculateMatchingNumberCount(currentCard);
            if (matchCount is 0)
            {
                continue;
            }

            for (var j = 1; j < matchCount + 1; j++)
            {
                var newCopyIndex = i + j;
                if (cardCopies.IsIndexValid(j))
                {
                    cardCopies[newCopyIndex] = cardCopies[newCopyIndex] with { CopyCount = cardCopies[newCopyIndex].CopyCount + currentCardCopies };

                }
            }
        }

        return cardCopies.Sum(c => c.CopyCount);
    }

    public int CalculateScore(string card)
    {
        var matchingNumberCount = CalculateMatchingNumberCount(card);
        if (matchingNumberCount is 0)
        {
            return matchingNumberCount;
        }


        return (int) Math.Pow(2, matchingNumberCount - 1);
    }

    public int CalculateMatchingNumberCount(string card)
    {
        var matchingNumberCount = 0;

        var cardData = GetCardData(card);

        var scoringNumbers = GetScoringNumbers(cardData);

        var scratchedNumbersStartIndex = cardData.IndexOf('|') + 1;
        foreach (var scratchedNumber in cardData[scratchedNumbersStartIndex..].SplitFast(" "))
        {
            if (!scratchedNumber.IsWhiteSpace())
            {
                var scratchedNumberParsed = int.Parse(scratchedNumber);
                if (scoringNumbers.Contains(scratchedNumberParsed))
                {
                    matchingNumberCount++;
                }
            }
        }

        return matchingNumberCount;
    }

    private static ReadOnlySpan<char> GetCardData(string card)
    {
        var splitIndex = card.IndexOf(':') + 2;
        return card.AsSpan()[splitIndex..];
    }

    private static HashSet<int> GetScoringNumbers(ReadOnlySpan<char> cardData)
    {
        var scoringNumbers = new HashSet<int>();

        var scoringNumbersEndIndex = cardData.IndexOf('|') - 1;
        foreach (var number in cardData[..scoringNumbersEndIndex].SplitFast(" "))
        {
            if (!number.IsWhiteSpace())
            {

                scoringNumbers.Add(int.Parse(number));
            }
        }

        return scoringNumbers;
    }
}