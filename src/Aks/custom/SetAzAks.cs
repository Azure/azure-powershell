using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    [Cmdlet(VerbsCommon.Set, AzureRMConstants.AzureRMPrefix + "Aks", SupportsShouldProcess = true)]
    [OutputType(typeof(IManagedCluster))]
    [Description(@"Updates a managed cluster with the specified configuration for agents and Kubernetes version.")]
    public class SetAzAks : NewAzAksBase
    {
        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A IAksIdentity object, normally passed through the pipeline.",
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public IAksIdentity InputObject { get; set; }

        /// <summary>
        ///     Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = Constants.IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        protected override async Task ProcessInternal()
        {
            switch (ParameterSetName)
            {
                case Constants.IdParameterSet:
                {
                    var resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
                case Constants.InputObjectParameterSet:
                {
                    var resource = new ResourceIdentifier(InputObject.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
            }

            //TODO: check the properties that could not set

            await Client.ManagedClustersCreateOrUpdate(SubscriptionId, ResourceGroupName, Name, ParametersBody, onOk,
                onDefault, this, Pipeline);
        }
    }
}