namespace AoC.Helpers;

public static class ReadInputHelper
{
    public static List<string> ReadInput(string filePath)
    {
        try
        {
            return File.ReadLines(filePath).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}