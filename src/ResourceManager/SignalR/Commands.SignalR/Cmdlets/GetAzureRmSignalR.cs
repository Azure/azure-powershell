using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR
{
    [Cmdlet(VerbsCommon.Get, SignalRNoun, DefaultParameterSetName = ListSignalRServiceParameterSet)]
    [OutputType(typeof(PSSignalRResource))]
    public class GetAzureRmSignalR : SignalRCmdletBase
    {
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = ListSignalRServiceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name.")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ListSignalRServiceParameterSet:
                        var signalrs = string.IsNullOrEmpty(ResourceGroupName)
                                     ? Client.Signalr.ListBySubscription()
                                     : Client.Signalr.ListByResourceGroup(ResourceGroupName);
                        foreach (var s in signalrs)
                        {
                            WriteObject(new PSSignalRResource(s));
                        }
                        break;
                    case ResourceGroupParameterSet:
                        var signalr = Client.Signalr.Get(ResourceGroupName, Name);
                        WriteObject(new PSSignalRResource(signalr));
                        break;
                    case ResourceIdParameterSet:
                        var resource = new ResourceIdentifier(ResourceId);
                        var idSignalR = Client.Signalr.Get(resource.ResourceGroupName, resource.ResourceName);
                        WriteObject(new PSSignalRResource(idSignalR));
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
            });
        }
    }
}
