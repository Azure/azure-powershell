namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile of managed cluster add-on.</summary>
    public partial class ManagedClusterPropertiesAddonProfiles :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfilesInternal
    {

        /// <summary>Creates an new <see cref="ManagedClusterPropertiesAddonProfiles" /> instance.</summary>
        public ManagedClusterPropertiesAddonProfiles()
        {

        }
    }
    /// Profile of managed cluster add-on.
    public partial interface IManagedClusterPropertiesAddonProfiles :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile>
    {

    }
    /// Profile of managed cluster add-on.
    internal partial interface IManagedClusterPropertiesAddonProfilesInternal

    {

    }
}