using System.Text.Json.Serialization;

namespace Task2;

public class TestData
{
    [JsonPropertyName("OSCheckBox")]
    public string OS { get; set; }

    [JsonPropertyName("NumbersPlayersCheckBox")]
    public string NumbersPlayers { get; set; }

    [JsonPropertyName("TagCheckBox")]
    public string Tag { get; set; }
}
