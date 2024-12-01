using AoC.Helpers;

namespace AoC;

public class DayOne
{
    public record DayOneOutput(int totalDifference, int similarityScore);
    
    public DayOneOutput GetTotalDifferenceAndSimilarityScore()
    {
        var input = ReadInputHelper.ReadInput("Inputs/dayOneInput.txt");
        
        var procesedListLeftSide = input
            .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(parts => (int.Parse(parts[0])))
            .Order()
            .ToList();

        var processedListRightSide = input
            .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(parts => (int.Parse(parts[1])))
            .Order()
            .ToList();
        
        var mergedList = MergeLists(procesedListLeftSide, processedListRightSide);
        var totalDifference = FindTotalDifference(mergedList);
        var similarityScore = FindSimilarityScore(procesedListLeftSide, processedListRightSide);

        return new DayOneOutput(totalDifference, similarityScore);

    }
    
    private List<(int, int)> MergeLists(List<int> procesedListLeftSide, List<int> processedListRightSide)
    {
        var mergedList = new List<(int, int)> { };
        for (int i = 0; i< procesedListLeftSide.Count; i ++)
        {
            mergedList.Add((procesedListLeftSide[i], processedListRightSide[i]));
        }
        return mergedList;
    }

    private int FindSimilarityScore(List<int> procesedListLeftSide, List<int> processedListRightSide)
    {
        int similarityScore = 0;

        foreach (var value in procesedListLeftSide)
        {
            var numberOfAppearancesInRightList = processedListRightSide.Count(x => x.Equals(value));
            int temporarySimilarityScore = value * numberOfAppearancesInRightList;
            similarityScore += temporarySimilarityScore;
        }

        return similarityScore;
    }

    private int FindTotalDifference(List<(int, int)> mergedList)
    {
        int totalDifference = 0;
        
        foreach (var item in mergedList)
        {
            var difference = Math.Abs(item.Item1 - item.Item2);
            totalDifference += difference;
        }

        return totalDifference;
    }
}