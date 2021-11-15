namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>Metadata for log analytics.</summary>
    public partial class LogAnalyticsMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadataInternal
    {

        /// <summary>Creates an new <see cref="LogAnalyticsMetadata" /> instance.</summary>
        public LogAnalyticsMetadata()
        {

        }
    }
    /// Metadata for log analytics.
    public partial interface ILogAnalyticsMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<string>
    {

    }
    /// Metadata for log analytics.
    internal partial interface ILogAnalyticsMetadataInternal

    {

    }
}