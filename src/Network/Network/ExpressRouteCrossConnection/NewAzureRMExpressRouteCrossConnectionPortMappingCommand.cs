using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzExpressRouteCrossConnectionPortMapping")]
    [OutputType(typeof(PSExpressRouteCrossConnectionPortMapping))]
    public class NewAzureRMExpressRouteCrossConnectionPortMappingCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The source port identifier supplied by the provider.")]
        [ValidateNotNullOrEmpty]
        public string SourcePortId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target port identifier supplied by the provider.")]
        [ValidateNotNullOrEmpty]
        public string TargetPortId { get; set; }

        public override void Execute()
        {
            WriteObject(new PSExpressRouteCrossConnectionPortMapping
            {
                SourcePortId = SourcePortId,
                TargetPortId = TargetPortId
            });
        }
    }
}