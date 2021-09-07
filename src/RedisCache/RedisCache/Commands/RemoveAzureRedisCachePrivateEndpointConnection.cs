
namespace Microsoft.Azure.Commands.RedisCache
{
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Properties;
    using Models;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisPrivateEndpointConnection", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRedisCachePrivateEndpointConnection : RedisCacheCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "The resource group name of the private endpoint.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache from private endpoint connection is deleted .")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of private endpoint connection to be deleted.")]
        [ValidateNotNullOrEmpty]
        public string PrivateEndpointConnectionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            ConfirmAction(Force.IsPresent,
                string.Format(Resources.RemovingRedisPrivateEndpointConnection, Name, PrivateEndpointConnectionName),
                string.Format(Resources.RemoveRedisPrivateEndpointConnection, Name, PrivateEndpointConnectionName),
                Name,
                () =>
                {
                    CacheClient.RemoveRedisPrivateEndpointConnection(ResourceGroupName, Name, PrivateEndpointConnectionName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
