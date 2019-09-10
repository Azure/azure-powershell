using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection"), OutputType(typeof(PSPrivateLinkService))]
    public class SetAzurePrivateEndpointConnection : PrivateLinkServiceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The private link service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Approved or rejected the resource.")]
        [PSArgumentCompleter("Approved","Rejected","Removed")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkServiceConnectionState { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The reason of action.")]
        public string Description { get; set; }

        public override void Execute()
        {
            base.Execute();

            var psPrivateLinkService = this.GetPrivateLinkService(ResourceGroupName, ServiceName);
            var obj = psPrivateLinkService.PrivateEndpointConnections.Find(x => x.Name == Name);
            if (obj != null)
            {
                obj.PrivateLinkServiceConnectionState.Status = PrivateLinkServiceConnectionState;
                obj.PrivateLinkServiceConnectionState.Description = Description;

                var plsConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PrivateEndpointConnection>(obj);
                this.PrivateLinkServiceClient.UpdatePrivateEndpointConnection(ResourceGroupName, ServiceName, Name, plsConnectionModel);

                var getPrivateLinkService = GetPrivateLinkService(ResourceGroupName, ServiceName);
                WriteObject(getPrivateLinkService);
            }
        }
    }
}
