namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Http listener of an application gateway.</summary>
    public partial class ApplicationGatewayHttpListener :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendIPConfigurationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendIPConfigurationId = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendPortId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendPortId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendPortId = value; }

        /// <summary>Host name of HTTP listener.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).HostName = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for FrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerInternal.FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Internal Acessors for FrontendPort</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerInternal.FrontendPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).FrontendPort = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayHttpListenerPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SslCertificate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerInternal.SslCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).SslCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).SslCertificate = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormat _property;

        /// <summary>Properties of HTTP listener of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayHttpListenerPropertiesFormat()); set => this._property = value; }

        /// <summary>Protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Applicable only if protocol is https. Enables SNI for multi-hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? RequireServerNameIndication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).RequireServerNameIndication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).RequireServerNameIndication = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SslCertificateId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).SslCertificateId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormatInternal)Property).SslCertificateId = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayHttpListener" /> instance.</summary>
        public ApplicationGatewayHttpListener()
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
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// Http listener of an application gateway.
    public partial interface IApplicationGatewayHttpListener :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string FrontendIPConfigurationId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string FrontendPortId { get; set; }
        /// <summary>Host name of HTTP listener.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host name of HTTP listener.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get; set; }
        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protocol.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Applicable only if protocol is https. Enables SNI for multi-hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Applicable only if protocol is https. Enables SNI for multi-hosting.",
        SerializedName = @"requireServerNameIndication",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RequireServerNameIndication { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SslCertificateId { get; set; }
        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Http listener of an application gateway.
    internal partial interface IApplicationGatewayHttpListenerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Frontend IP configuration resource of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource FrontendIPConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string FrontendIPConfigurationId { get; set; }
        /// <summary>Frontend port resource of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource FrontendPort { get; set; }
        /// <summary>Resource ID.</summary>
        string FrontendPortId { get; set; }
        /// <summary>Host name of HTTP listener.</summary>
        string HostName { get; set; }
        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Properties of HTTP listener of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListenerPropertiesFormat Property { get; set; }
        /// <summary>Protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Applicable only if protocol is https. Enables SNI for multi-hosting.</summary>
        bool? RequireServerNameIndication { get; set; }
        /// <summary>SSL certificate resource of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource SslCertificate { get; set; }
        /// <summary>Resource ID.</summary>
        string SslCertificateId { get; set; }
        /// <summary>Type of the resource.</summary>
        string Type { get; set; }

    }
}