using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redisclient
{
    class Program
    {
        static void Main(string[] args)
        {

            IDatabase cache = Connection.GetDatabase();

            cache.StringSet("key1", "value");
            cache.StringSet("key2", 25);

            string key1 = cache.StringGet("key1");
            int key2 = (int)cache.StringGet("key2");
        }


        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("eus-catalog3-redis-prod.redis.cache.windows.net,abortConnect=false,ssl=true,password=");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
