using System;

namespace Cache.Configuration
{
    public class CacheConfiguration
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 6379;
        public int Database { get; set; } = 0;
        public TimeSpan DefaultTtl { get; set; } = TimeSpan.FromMinutes(60);
        public bool AllowAdmin { get; set; } = false;
        public string Prefix { get; set; } = "app:";

        public string BuildConnectionString()
        {
            return $"{Host}:{Port},defaultDatabase={Database}";
        }
    }
}
