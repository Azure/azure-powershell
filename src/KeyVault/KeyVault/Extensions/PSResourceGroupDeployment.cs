using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
    public class PSResourceGroupDeployment : PSDeploymentObject
    {
        public string ResourceGroupName { get; set; }

        public OnErrorDeploymentExtended OnErrorDeployment { get; set; }
    }
}