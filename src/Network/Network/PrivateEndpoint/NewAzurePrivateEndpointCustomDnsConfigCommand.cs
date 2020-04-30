using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointCustomDnsConfig"), OutputType(typeof(PSPrivateEndpointCustomDnsConfig))]
    public class NewAzurePrivateEndpointCustomDnsConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Fqdn that resolves to private endpoint ip address.")]
        [ValidateNotNullOrEmpty]
        public string Fqdn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A list of private ip addresses of the private endpoint.")]
        [ValidateNotNullOrEmpty]
        public List<string> IpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            var dnsConfig = new PSPrivateEndpointCustomDnsConfig();
            dnsConfig.Fqdn = Fqdn;
            dnsConfig.IpAddresses = IpAddress;

            WriteObject(dnsConfig);
        }
    }
}
