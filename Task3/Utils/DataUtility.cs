using System.Text.Json;

namespace Task3;

public static class DataUtility
{
    private static JsonTestData jsonTestData;
    private static ConfigData configData;

    private static string GetBasePath()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var basePath = Path.Combine(currentDirectory, "../../../");
        return Path.GetFullPath(basePath);
    }

    private static string GetFilePath(string fileName) => Path.Combine(GetBasePath(), "JsonData", fileName);

    public static JsonTestData GetTestData
    {
        get
        {
            if (jsonTestData == null)
            {
                var filePath = GetFilePath("testData.json");
                jsonTestData = ReadJson<JsonTestData>(filePath);
            }
            return jsonTestData;
        }
    }

    public static ConfigData GetConfigData
    {
        get
        {
            if (configData == null)
            {
                var filePath = GetFilePath("config.json");
                configData = ReadJson<ConfigData>(filePath);
            }
            return configData;
        }
    }

    private static T ReadJson<T>(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}
