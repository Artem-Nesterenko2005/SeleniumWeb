namespace Task3;

public static class RandomGenerate
{
    public static string GetRandomString()
    {
        var randomString = Guid.NewGuid().ToString();
        return randomString;
    }
}
