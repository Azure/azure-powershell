namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Extensions;

    /// <summary>Metadata attached to the inbound endpoint.</summary>
    public partial class InboundEndpointPropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadataInternal
    {

        /// <summary>Creates an new <see cref="InboundEndpointPropertiesMetadata" /> instance.</summary>
        public InboundEndpointPropertiesMetadata()
        {

        }
    }
    /// Metadata attached to the inbound endpoint.
    public partial interface IInboundEndpointPropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IAssociativeArray<string>
    {

    }
    /// Metadata attached to the inbound endpoint.
    internal partial interface IInboundEndpointPropertiesMetadataInternal

    {

    }
}