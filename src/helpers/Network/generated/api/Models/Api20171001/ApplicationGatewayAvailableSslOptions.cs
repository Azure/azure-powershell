namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ApplicationGatewayAvailableSslOptions API service call.</summary>
    public partial class ApplicationGatewayAvailableSslOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Resource();

        /// <summary>List of available Ssl cipher suites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).AvailableCipherSuite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).AvailableCipherSuite = value; }

        /// <summary>List of available Ssl protocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).AvailableProtocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).AvailableProtocol = value; }

        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).DefaultPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).DefaultPolicy = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayAvailableSslOptionsPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; }

        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] PredefinedPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).PredefinedPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal)Property).PredefinedPolicy = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormat _property;

        /// <summary>Properties of ApplicationGatewayAvailableSslOptions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayAvailableSslOptionsPropertiesFormat()); set => this._property = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ApplicationGatewayAvailableSslOptions" /> instance.</summary>
        public ApplicationGatewayAvailableSslOptions()
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
    /// Response for ApplicationGatewayAvailableSslOptions API service call.
    public partial interface IApplicationGatewayAvailableSslOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource
    {
        /// <summary>List of available Ssl cipher suites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl cipher suites.",
        SerializedName = @"availableCipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get; set; }
        /// <summary>List of available Ssl protocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl protocols.",
        SerializedName = @"availableProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get; set; }
        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Ssl predefined policy applied by default to application gateway",
        SerializedName = @"defaultPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl predefined policy.",
        SerializedName = @"predefinedPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] PredefinedPolicy { get; set; }

    }
    /// Response for ApplicationGatewayAvailableSslOptions API service call.
    internal partial interface IApplicationGatewayAvailableSslOptionsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal
    {
        /// <summary>List of available Ssl cipher suites.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get; set; }
        /// <summary>List of available Ssl protocols.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get; set; }
        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] PredefinedPolicy { get; set; }
        /// <summary>Properties of ApplicationGatewayAvailableSslOptions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAvailableSslOptionsPropertiesFormat Property { get; set; }

    }
}