namespace Iyo.util;

public class InputValidator
{
    public static void validateIntInput(string input)
    {
        try
        {
            int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine("Warning: Input has to be integer");
        }
    }
}