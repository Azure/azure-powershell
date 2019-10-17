using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId"), OutputType(typeof(PSPrivateEndpointConnection))]
    public class SetAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Approved or rejected the resource.")]
        [PSArgumentCompleter("Approved","Rejected","Removed")]
        public string PrivateLinkServiceConnectionState { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The reason of action.")]
        public string Description { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;

                if (this.ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Contains("privateEndpointConnections"))
                {
                    this.Name = resourceIdentifier.ResourceName;
                    this.ResourceType = resourceIdentifier.ResourceType;
                    string parentResource = resourceIdentifier.ParentResource;
                    this.ServiceName = parentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                }
                else
                {
                    throw new ArgumentException(string.Format(Properties.Resources.InvalidResourceId, "[ServiceProvider]/privateEndpointConnections"));
                }
            }

            IPrivateLinkProvider provider = BuildProvider(this.ResourceType);

            var pec = provider.UpdatePrivateEndpointConnectionStatus(this.ResourceGroupName, this.ServiceName, this.Name, this.PrivateLinkServiceConnectionState, this.Description);
            WriteObject(pec);
        }
    }
}
