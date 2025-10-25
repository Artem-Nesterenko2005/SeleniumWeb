using System.Text.Json.Serialization;

namespace Task2;

public class ConfigData
{
    [JsonPropertyName("Language")]
    public string Language { get; set; }

    [JsonPropertyName("OpenMode")]
    public string OpenMode { get; set; }

    [JsonPropertyName("URL")]
    public string URL { get; set; }

    [JsonPropertyName("WaitTime")]
    public int WaitTime { get; set; }
}
