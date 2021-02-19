namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Extensions;

    /// <summary>Describes an inbound endpoint for a DNS resolver.</summary>
    public partial class InboundEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.Resource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>ETag of the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>IP configurations for the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IIPConfiguration[] IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).IPConfiguration = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Id; }

        /// <summary>Metadata attached to the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadata Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointProperties Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.InboundEndpointProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointInternal.ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ResourceGuid = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointProperties _property;

        /// <summary>Properties of the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.InboundEndpointProperties()); set => this._property = value; }

        /// <summary>
        /// The current provisioning state of the inbound endpoint. This is a read-only property and any attempt to set this value
        /// will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The resourceGuid property of the inbound endpoint resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesInternal)Property).ResourceGuid; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="InboundEndpoint" /> instance.</summary>
        public InboundEndpoint()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Describes an inbound endpoint for a DNS resolver.
    public partial interface IInboundEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResource
    {
        /// <summary>ETag of the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ETag of the inbound endpoint.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>IP configurations for the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP configurations for the inbound endpoint.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Metadata attached to the inbound endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metadata attached to the inbound endpoint.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadata Metadata { get; set; }
        /// <summary>
        /// The current provisioning state of the inbound endpoint. This is a read-only property and any attempt to set this value
        /// will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current provisioning state of the inbound endpoint. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The resourceGuid property of the inbound endpoint resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resourceGuid property of the inbound endpoint resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get;  }

    }
    /// Describes an inbound endpoint for a DNS resolver.
    internal partial interface IInboundEndpointInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20.IResourceInternal
    {
        /// <summary>ETag of the inbound endpoint.</summary>
        string Etag { get; set; }
        /// <summary>IP configurations for the inbound endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Metadata attached to the inbound endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointPropertiesMetadata Metadata { get; set; }
        /// <summary>Properties of the inbound endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpointProperties Property { get; set; }
        /// <summary>
        /// The current provisioning state of the inbound endpoint. This is a read-only property and any attempt to set this value
        /// will be ignored.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The resourceGuid property of the inbound endpoint resource.</summary>
        string ResourceGuid { get; set; }

    }
}