namespace Patient_and_Pet_Management.Utils;

public static class Sleep
{
    public static async Task<string> Wait(int seconds)
    {
        await Task.Delay(seconds);
        return "Riwi";
    }
}