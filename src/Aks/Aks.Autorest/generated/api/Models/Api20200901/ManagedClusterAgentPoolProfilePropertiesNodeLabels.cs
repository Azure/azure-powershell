namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
    public partial class ManagedClusterAgentPoolProfilePropertiesNodeLabels :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabelsInternal
    {

        /// <summary>
        /// Creates an new <see cref="ManagedClusterAgentPoolProfilePropertiesNodeLabels" /> instance.
        /// </summary>
        public ManagedClusterAgentPoolProfilePropertiesNodeLabels()
        {

        }
    }
    /// Agent pool node labels to be persisted across all nodes in agent pool.
    public partial interface IManagedClusterAgentPoolProfilePropertiesNodeLabels :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<string>
    {

    }
    /// Agent pool node labels to be persisted across all nodes in agent pool.
    internal partial interface IManagedClusterAgentPoolProfilePropertiesNodeLabelsInternal

    {

    }
}