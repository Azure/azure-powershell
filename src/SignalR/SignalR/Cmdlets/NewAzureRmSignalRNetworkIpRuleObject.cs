using System.Management.Automation;
using Microsoft.Azure.Commands.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRNetworkIpRuleObject", SupportsShouldProcess = false)]
    [OutputType(typeof(PSIpRule))]
    public class NewAzureRmSignalRNetworkIpRuleObject : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "IP rule value. Accepts IP, CIDR or ServiceTag.")]
        public string Value { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Action for the IP rule. Allow or Deny. Default: Allow")]
        [ValidateSet("Allow", "Deny", IgnoreCase = true)]
        public string Action { get; set; } = "Allow";

        protected override void ProcessRecord()
        {
            WriteObject(new PSIpRule { Value = Value, Action = Action });
        }
    }
}
