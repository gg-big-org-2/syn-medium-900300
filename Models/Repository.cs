using System;
using System.Text.Json.Serialization;

public class Repository
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("is_private")]
    public bool IsPrivate { get; set; }

    public static Repository FromJson(string json)
    {
        return System.Text.Json.JsonSerializer.Deserialize<Repository>(json);
    }
}
