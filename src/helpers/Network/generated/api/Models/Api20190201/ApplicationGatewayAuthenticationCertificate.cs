namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Authentication certificates of an application gateway.</summary>
    public partial class ApplicationGatewayAuthenticationCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificate,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>Certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Data { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal)Property).Data; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal)Property).Data = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayAuthenticationCertificatePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of the authentication certificate that is unique within an Application Gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormat _property;

        /// <summary>Properties of the application gateway authentication certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayAuthenticationCertificatePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAuthenticationCertificate" /> instance.
        /// </summary>
        public ApplicationGatewayAuthenticationCertificate()
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
    /// Authentication certificates of an application gateway.
    public partial interface IApplicationGatewayAuthenticationCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
    {
        /// <summary>Certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate public data.",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(string) })]
        string Data { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>
        /// Name of the authentication certificate that is unique within an Application Gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the authentication certificate that is unique within an Application Gateway.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Authentication certificates of an application gateway.
    internal partial interface IApplicationGatewayAuthenticationCertificateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>Certificate public data.</summary>
        string Data { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// Name of the authentication certificate that is unique within an Application Gateway.
        /// </summary>
        string Name { get; set; }
        /// <summary>Properties of the application gateway authentication certificate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormat Property { get; set; }
        /// <summary>
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Type of the resource.</summary>
        string Type { get; set; }

    }
}