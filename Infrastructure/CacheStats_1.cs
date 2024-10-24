using System;

namespace Cache.Monitoring
{
    public class CacheStats
    {
        public bool IsConnected { get; set; }
        public long HitCount { get; set; }
        public long MissCount { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ServerInfo { get; set; }

        public double HitRate
        {
            get
            {
                var total = HitCount + MissCount;
                return total == 0 ? 0 : (double)HitCount / total;
            }
        }

        public CacheStats()
        {
            LastUpdated = DateTime.UtcNow;
        }
    }
}
