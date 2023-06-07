using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
    public class PSDeployment : PSDeploymentObject
    {
        public string Id { get; set; }

        public string Location { get; set; }

        public string ManagementGroupId { get; set; }

        public string ResourceGroupName { get; set; }

        public OnErrorDeploymentExtended OnErrorDeployment { get; set; }
    }
}