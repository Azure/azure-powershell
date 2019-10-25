using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "Aks", SupportsShouldProcess = true)]
    [OutputType(typeof(IManagedCluster))]
    [Description(@"Creates a managed cluster with the specified configuration for agents and Kubernetes version.")]
    public class NewAzAks : NewAzAksBase
    {
    }
}