namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Key-value pairs for configuring an add-on.</summary>
    public partial class ManagedClusterAddonProfileConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfigInternal
    {

        /// <summary>Creates an new <see cref="ManagedClusterAddonProfileConfig" /> instance.</summary>
        public ManagedClusterAddonProfileConfig()
        {

        }
    }
    /// Key-value pairs for configuring an add-on.
    public partial interface IManagedClusterAddonProfileConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<string>
    {

    }
    /// Key-value pairs for configuring an add-on.
    internal partial interface IManagedClusterAddonProfileConfigInternal

    {

    }
}