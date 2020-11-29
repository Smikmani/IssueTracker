using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Extensions
{
    public static class DistrributedCacheExtension
    {
        public static void Set<T>(this IDistributedCache cache, string key, T value) where T : class
        {
            var data = JsonSerializer.Serialize(value);
            cache.SetString(key, data, new DistributedCacheEntryOptions() { AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(5) });
        }
        public static T Get<T>(this IDistributedCache cache, string key) where T : class
        {
            var data = cache.GetString(key);
            return data == null ? null : JsonSerializer.Deserialize<T>((string)data);
        }
    }
}
