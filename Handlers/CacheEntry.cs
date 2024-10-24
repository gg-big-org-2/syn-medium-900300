using System;
using System.Text.Json.Serialization;

namespace Cache.Models
{
    public class CacheEntry
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }

        [JsonPropertyName("ttlSeconds")]
        public long? TtlSeconds { get; set; }

        public CacheEntry() { }

        public CacheEntry(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
