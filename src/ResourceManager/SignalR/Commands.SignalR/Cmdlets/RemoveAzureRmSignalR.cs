using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR
{
    [Cmdlet(VerbsCommon.Remove, SignalRNoun, SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmSignalR : SignalRCmdletBase, IWithInputObject, IWithResourceId
    {
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

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromResourceId();
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromInputObject();
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }

                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "remove"))
                {
                    Client.Signalr.Delete(ResourceGroupName, Name);
                }

                if (PassThru)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
