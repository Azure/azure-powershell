
namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using System;
    using Management.Redis.Models;

    public class PSRedisPrivateEndpoint
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }

        public string PrivateEndpointName { get; set; }
        public string ConnectionStatus { get; set; }
        

       // public PSRedisPrivateEndpoint() { }

        public PSRedisPrivateEndpoint(string resourceGroupName, string cacheName, PrivateEndpointConnection redisPrivateEndpoint)
        {
            ResourceGroupName = resourceGroupName;
            Name = cacheName;

            PrivateEndpointName = redisPrivateEndpoint.Name;
            ConnectionStatus = redisPrivateEndpoint.PrivateLinkServiceConnectionState.Status;
        }
    }
}