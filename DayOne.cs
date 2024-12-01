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
        return procesedListLeftSide
            .Zip(processedListRightSide)
            .ToList();
    }

    private int FindSimilarityScore(List<int> procesedListLeftSide, List<int> processedListRightSide)
    {
        return procesedListLeftSide
            .Sum(leftSideInt => leftSideInt * processedListRightSide.Count(rightSideInt => rightSideInt.Equals(leftSideInt)));
        
    }

    private int FindTotalDifference(List<(int, int)> mergedList)
    {
        return mergedList.Sum(x => Math.Abs(x.Item1 - x.Item2));
    }
}