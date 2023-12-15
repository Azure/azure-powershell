namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Dictionary of <ExtendedErrorInfo></summary>
    public partial class RolloutStatusBaseFailedOrSkippedRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegionsInternal
    {

        /// <summary>Creates an new <see cref="RolloutStatusBaseFailedOrSkippedRegions" /> instance.</summary>
        public RolloutStatusBaseFailedOrSkippedRegions()
        {

        }
    }
    /// Dictionary of <ExtendedErrorInfo>
    public partial interface IRolloutStatusBaseFailedOrSkippedRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo>
    {

    }
    /// Dictionary of <ExtendedErrorInfo>
    internal partial interface IRolloutStatusBaseFailedOrSkippedRegionsInternal

    {

    }
}