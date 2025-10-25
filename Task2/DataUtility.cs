using System.Text.Json;

namespace Task2;

public static class DataUtility
{
    private static TestData testData;
    private static ConfigData configData;

    public static TestData GetTestData
    {
        get
        {
            if (testData == null)
            {
                testData = ReadJson<TestData>("../../../testData.json");
            }
            return testData;
        }
    }

    public static ConfigData GetConfigData
    {
        get
        {
            if (configData == null)
            {
                configData = ReadJson<ConfigData>("../../../config.json");
            }
            return configData;
        }
    }

    private static T ReadJson<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}
