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
    public class GetAzureRmSignalR : SignalRCmdletBase, IWithResourceId
    {
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = ListSignalRServiceParameterSet,
            HelpMessage = "The resource group name.")]
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The SignalR service name.")]
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
                    case ResourceIdParameterSet:
                        this.LoadFromResourceId();
                        var signalrById = Client.Signalr.Get(ResourceGroupName, Name);
                        WriteObject(new PSSignalRResource(signalrById));
                        break;
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        var signalr = Client.Signalr.Get(ResourceGroupName, Name);
                        WriteObject(new PSSignalRResource(signalr));
                        break;

                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
            });
        }
    }
}
