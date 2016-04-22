using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    public class ServerManagementGatewayProfileCmdletBase : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
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
        }
    }
}