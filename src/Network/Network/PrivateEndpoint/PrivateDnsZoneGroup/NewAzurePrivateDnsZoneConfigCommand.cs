using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZoneConfig"), OutputType(typeof(PSPrivateDnsZoneConfig))]
    public class NewAzurePrivateDnsZoneConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the resource that is unique within a resource group. This name can be used to access the resource.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource id of the private dns zone.")]
        [ValidateNotNullOrEmpty]
        public string PrivateDnsZoneId { get; set; }

        public override void Execute()
        {
            base.Execute();

            var zoneConfig = new PSPrivateDnsZoneConfig();
            zoneConfig.Name = Name;
            zoneConfig.PrivateDnsZoneId = PrivateDnsZoneId;

            WriteObject(zoneConfig);
        }
    }
}
