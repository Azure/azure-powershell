using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointIpConfiguration"), OutputType(typeof(PSPrivateEndpointIPConfiguration))]
    public class NewAzurePrivateEndpointIPConfigurationCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of a private endpoint IP configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The ID of a group that this private endpoint is associated with.")]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The member name of the group that this private endpoint is associated with.")]
        [ValidateNotNullOrEmpty]
        public string MemberName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The private ip address that is associated with this private endpoint's subnet.")]
        [ValidateNotNullOrEmpty]
        public string PrivateIPAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            var psPeIpConfig = new PSPrivateEndpointIPConfiguration
            {
                Name = Name,
                GroupId = GroupId,
                MemberName = MemberName,
                PrivateIPAddress = PrivateIPAddress
            };

            WriteObject(psPeIpConfig);
        }
    }
}
