using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    [Cmdlet(VerbsCommon.Reset, "AzureRmServerManagementGatewayProfile")]
    public class ResetServerManagementGatewayProfileCmdlet : ServerManagementGatewayProfileCmdletBase
    {
        // tells the service to regenerate the profile for a gateway

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose($"Regenerating profile for {ResourceGroupName}/{GatewayName}");
            Client.Gateway.RegenerateProfile(ResourceGroupName, GatewayName);
            WriteVerbose($"Successfully regenerated profile for {ResourceGroupName}/{GatewayName}");
        }
    }
}