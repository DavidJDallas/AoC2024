using AoC.Helpers;

namespace AoC;

public class DayTwo
{
    public int DayTwoTask()
    {
        var input = ReadInputHelper.ReadInput("Inputs/dayTwoInput.txt");
        var splitInput = input.Select(x => x.Split()).ToList();
        var intSplitInput = splitInput.Select(x => x.Select(y => int.Parse(y)).ToList());

        int totalCount = 0;

        foreach (var report in intSplitInput)
        {
            if (IsValidSequence(report))
            {
                totalCount++;
                continue;
            }
            bool foundValid = false;
            for (int i = 0; i < report.Count; i++)
            {
               
                var modifiedReport = new List<int>();
                for (int j = 0; j < report.Count; j++)
                {
                    if (j != i) modifiedReport.Add(report[j]);
                }

                if (IsValidSequence(modifiedReport))
                {
                    totalCount++;
                    foundValid = true;
                    break;
                }
            }
        }

        return totalCount;
    }

    private static bool IsValidSequence(IList<int> sequence)
    {
        if (!IsOrdered(sequence, 0))
        {
            return false;
        }
        
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            var difference = Math.Abs(sequence[i] - sequence[i + 1]);
            if (difference < 1 || difference > 3)
            {
                return false;
            }
        }

        return true;
    }
    
    
    private static bool IsOrdered(IList<int> sequence, int degreeOfFlexibility)
    {
        int ascendingCount = 0;
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            if (sequence[i] < sequence[i + 1])
            {
                ascendingCount++;
            }
        }
    
        int descendingCount = 0;
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            if (sequence[i] > sequence[i + 1])
            {
                descendingCount++;
            }
        }
    
        int requiredCount = sequence.Count - 1 - degreeOfFlexibility;
        return ascendingCount >= requiredCount || descendingCount >= requiredCount;
    }
}