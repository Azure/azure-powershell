namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Interface endpoint resource.</summary>
    public partial class InterfaceEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string EndpointServiceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).EndpointServiceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).EndpointServiceId = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2, Label = @"Domain Name")]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Fqdn = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for EndpointService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal.EndpointService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).EndpointService; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).EndpointService = value; }

        /// <summary>Internal Acessors for NetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal.NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).NetworkInterface = value; }

        /// <summary>Internal Acessors for Owner</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal.Owner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Owner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Owner = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InterfaceEndpointProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).NetworkInterface; }

        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3)]
        public string Owner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Owner; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties _property;

        /// <summary>Properties of the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InterfaceEndpointProperties()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal)Property).Subnet = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="InterfaceEndpoint" /> instance.</summary>
        public InterfaceEndpoint()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Interface endpoint resource.
    public partial interface IInterfaceEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique identifier of the service being referenced by the interface endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointServiceId { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an array of references to the network interfaces created for this interface endpoint.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get;  }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A read-only property that identifies who created this interface endpoint.",
        SerializedName = @"owner",
        PossibleTypes = new [] { typeof(string) })]
        string Owner { get;  }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the subnet from which the private IP will be allocated.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
    /// Interface endpoint resource.
    internal partial interface IInterfaceEndpointInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>A reference to the service being brought into the virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService EndpointService { get; set; }
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        string EndpointServiceId { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        string Fqdn { get; set; }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get; set; }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        string Owner { get; set; }
        /// <summary>Properties of the interface endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties Property { get; set; }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
}