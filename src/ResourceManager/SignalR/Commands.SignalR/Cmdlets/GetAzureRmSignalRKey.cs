using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, SignalRKeyNoun, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSSignalRKeys))]
    public class GetAzureRmSignalRKey : SignalRCmdletBase
    {
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "SignalR service name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The SignalR service resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                ResourceIdentifier resourceId = null;
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        break;
                    case ResourceIdParameterSet:
                        resourceId = new ResourceIdentifier(ResourceId);
                        break;
                    case InputObjectParameterSet:
                        resourceId = new ResourceIdentifier(InputObject.Id);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                if (resourceId != null)
                {
                    ResourceGroupName = resourceId.ResourceGroupName;
                    Name = resourceId.ResourceName;
                }

                var keys = Client.Signalr.ListKeys(ResourceGroupName, Name);
                WriteObject(new PSSignalRKeys(Name, keys));
            });
        }
    }
}
