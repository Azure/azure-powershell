
namespace Microsoft.Azure.Commands.RedisCache.Commands
{
    using Microsoft.Azure.Commands.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Azure.Management.Redis.Models;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisPrivateEndpointConnection"), OutputType(typeof(PSRedisPrivateEndpoint))]

    public class GetAzureRedisCachePrivateEndpointConnection : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The resource group name of the private endpoint.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of private endpoint connection.")]
        [ValidateNotNullOrEmpty]
        public string PrivateEndpointConnectionName { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            if(!string.IsNullOrEmpty(PrivateEndpointConnectionName))
            {
                var redisPrivateEndpointConnection = CacheClient.GetRedisPrivateEndpointConnection(
                        resourceGroupName: ResourceGroupName,
                        cacheName: Name,
                        privateEndpointConnectionName: PrivateEndpointConnectionName);
                /*if(redisPrivateEndpointConnection==null)
                {
                    throw new CloudException(string.Format(Resources.PrivateEndpointNameNotFound, Name, PrivateEndpointConnectionName));
                }*/
                WriteObject(new PSRedisPrivateEndpoint(ResourceGroupName, Name, redisPrivateEndpointConnection));

            }
            else
            {
                IEnumerable<PrivateEndpointConnection> response = CacheClient.ListPrivateEndpoints(ResourceGroupName, Name);
                //IPage<PrivateEndpointConnection> response = CacheClient.ListPrivateEndpoints(ResourceGroupName,Name);
                List<PSRedisPrivateEndpoint> list = new List<PSRedisPrivateEndpoint>();
                foreach (PrivateEndpointConnection redisPrivateEndpoint in response)
                {
                    list.Add(new PSRedisPrivateEndpoint(ResourceGroupName, Name, redisPrivateEndpoint));
                }
                WriteObject(list, true);

               /* while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    // List using next link
                    response = CacheClient.ListPrivateEndpoints(response.NextPageLink);
                    list = new List<PSRedisPrivateEndpoint>();
                    foreach (PrivateEndpointConnection redisPrivateEndpoint in response)
                    {
                        list.Add(new PSRedisPrivateEndpoint(ResourceGroupName, Name, redisPrivateEndpoint));
                    }
                    WriteObject(list, true);
                }*/
            }
        }
    }
}
