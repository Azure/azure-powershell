
namespace Microsoft.Azure.Commands.RedisCache
{
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Properties;
    using Models;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisPrivateEndpointConnectionStatus", SupportsShouldProcess = true), OutputType(typeof(PSRedisPrivateEndpoint))]
    public class SetAzureRedisCachePrivateEndpointConnectionStatus : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The resource group name of the private endpoint.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache from private endpoint connection status is edited.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of private endpoint whose connection status to be edited.")]
        [ValidateNotNullOrEmpty]
        public string PrivateEndpointConnectionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Connection status - Approved, Pending, Rejected")]
        [ValidateNotNullOrEmpty]
        public string ConnectionStatus { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(
                string.Format(Resources.SetRedisPrivateEndpoint,Name,PrivateEndpointConnectionName,ConnectionStatus),
                Name,
                () =>
                {
                    var redisPrivateEndpoint = CacheClient.SetRedisPrivateEndpointConnection(ResourceGroupName, Name, PrivateEndpointConnectionName, ConnectionStatus);
                    WriteObject(new PSRedisPrivateEndpoint(ResourceGroupName, Name, redisPrivateEndpoint));
                });
        }

    }
}
