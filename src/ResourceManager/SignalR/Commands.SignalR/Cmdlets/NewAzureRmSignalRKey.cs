using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet(VerbsCommon.New, SignalRKeyNoun, SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSSignalRKeys))]
    public class NewAzureRmSignalRKey : SignalRCmdletBase
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

        [Parameter(Mandatory = true, HelpMessage = "The key type, either Primary or Secondary.")]
        [PSArgumentCompleter("Primary", "Secondary")]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string KeyType { get; set; }

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

                if (ShouldProcess($"{KeyType} key for {ResourceGroupName}/{Name}", "regenerate"))
                {
                    var keys = Client.Signalr.RegenerateKey(ResourceGroupName, Name, new RegenerateKeyParameters(KeyType));
                    WriteObject(new PSSignalRKeys(Name, keys));
                }
            });
        }
    }
}
