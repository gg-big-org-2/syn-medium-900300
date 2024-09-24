// detector: redis_cli
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Cache.Services
{
    public class RedisCache
    {
        private IConnectionMultiplexer _connection;
        private readonly string _redisUrl;

        public RedisCache(string redisUrl)
        {
            _redisUrl = redisUrl;
        }

        public async Task InitializeAsync()
        {
            var options = ConfigurationOptions.Parse(_redisUrl);
            options.AbortOnConnectFail = false;
            _connection = await ConnectionMultiplexer.ConnectAsync(options);
        }

        public async Task<string> GetAsync(string key)
        {
            var db = _connection.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            var db = _connection.GetDatabase();
            await db.StringSetAsync(key, value, expiry);
        }
    }
}
