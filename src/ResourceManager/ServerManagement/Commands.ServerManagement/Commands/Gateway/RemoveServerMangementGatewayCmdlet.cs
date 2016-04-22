using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Gateway
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementGateway")]
    public class RemoveServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true,ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway to delete.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }
        #endregion

        #region ByObject
        [Parameter(Mandatory = true, HelpMessage = "The gateway to delete.", ValueFromPipeline = true, ParameterSetName = "ByObject")]
        [ValidateNotNull]
        public Model.Gateway Gateway { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Gateway != null)
            {
                WriteVerbose($"Using Gateway object for resource/gateway name");
                ResourceGroupName = Gateway.ResourceGroupName;
                GatewayName = Gateway.Name;
            }

            WriteVerbose($"Removing gateway for {ResourceGroupName}/{GatewayName}");
            // delete the gateway.
            Client.Gateway.Delete(ResourceGroupName, GatewayName);
        }

    }
}