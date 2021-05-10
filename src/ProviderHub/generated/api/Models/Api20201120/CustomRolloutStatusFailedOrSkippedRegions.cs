namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Dictionary of <ExtendedErrorInfo></summary>
    public partial class CustomRolloutStatusFailedOrSkippedRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutStatusFailedOrSkippedRegions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutStatusFailedOrSkippedRegionsInternal
    {

        /// <summary>
        /// Creates an new <see cref="CustomRolloutStatusFailedOrSkippedRegions" /> instance.
        /// </summary>
        public CustomRolloutStatusFailedOrSkippedRegions()
        {

        }
    }
    /// Dictionary of <ExtendedErrorInfo>
    public partial interface ICustomRolloutStatusFailedOrSkippedRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo>
    {

    }
    /// Dictionary of <ExtendedErrorInfo>
    internal partial interface ICustomRolloutStatusFailedOrSkippedRegionsInternal

    {

    }
}