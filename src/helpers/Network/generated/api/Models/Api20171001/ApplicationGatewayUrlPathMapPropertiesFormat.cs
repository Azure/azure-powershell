namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of UrlPathMap of the application gateway.</summary>
    public partial class ApplicationGatewayUrlPathMapPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMapPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMapPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="DefaultBackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _defaultBackendAddressPool;

        /// <summary>Default backend address pool resource of URL path map.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultBackendAddressPool { get => (this._defaultBackendAddressPool = this._defaultBackendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._defaultBackendAddressPool = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DefaultBackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultBackendAddressPool).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultBackendAddressPool).Id = value; }

        /// <summary>Backing field for <see cref="DefaultBackendHttpSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _defaultBackendHttpSetting;

        /// <summary>Default backend http settings resource of URL path map.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultBackendHttpSetting { get => (this._defaultBackendHttpSetting = this._defaultBackendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._defaultBackendHttpSetting = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DefaultBackendHttpSettingId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultBackendHttpSetting).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultBackendHttpSetting).Id = value; }

        /// <summary>Backing field for <see cref="DefaultRedirectConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _defaultRedirectConfiguration;

        /// <summary>Default redirect configuration resource of URL path map.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultRedirectConfiguration { get => (this._defaultRedirectConfiguration = this._defaultRedirectConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._defaultRedirectConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DefaultRedirectConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultRedirectConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)DefaultRedirectConfiguration).Id = value; }

        /// <summary>Internal Acessors for DefaultBackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMapPropertiesFormatInternal.DefaultBackendAddressPool { get => (this._defaultBackendAddressPool = this._defaultBackendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_defaultBackendAddressPool = value;} } }

        /// <summary>Internal Acessors for DefaultBackendHttpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMapPropertiesFormatInternal.DefaultBackendHttpSetting { get => (this._defaultBackendHttpSetting = this._defaultBackendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_defaultBackendHttpSetting = value;} } }

        /// <summary>Internal Acessors for DefaultRedirectConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMapPropertiesFormatInternal.DefaultRedirectConfiguration { get => (this._defaultRedirectConfiguration = this._defaultRedirectConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_defaultRedirectConfiguration = value;} } }

        /// <summary>Backing field for <see cref="PathRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRule[] _pathRule;

        /// <summary>Path rule of URL path map resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRule[] PathRule { get => this._pathRule; set => this._pathRule = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayUrlPathMapPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayUrlPathMapPropertiesFormat()
        {

        }
    }
    /// Properties of UrlPathMap of the application gateway.
    public partial interface IApplicationGatewayUrlPathMapPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultBackendAddressPoolId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultBackendHttpSettingId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultRedirectConfigurationId { get; set; }
        /// <summary>Path rule of URL path map resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path rule of URL path map resource.",
        SerializedName = @"pathRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRule[] PathRule { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Properties of UrlPathMap of the application gateway.
    internal partial interface IApplicationGatewayUrlPathMapPropertiesFormatInternal

    {
        /// <summary>Default backend address pool resource of URL path map.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultBackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string DefaultBackendAddressPoolId { get; set; }
        /// <summary>Default backend http settings resource of URL path map.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultBackendHttpSetting { get; set; }
        /// <summary>Resource ID.</summary>
        string DefaultBackendHttpSettingId { get; set; }
        /// <summary>Default redirect configuration resource of URL path map.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource DefaultRedirectConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string DefaultRedirectConfigurationId { get; set; }
        /// <summary>Path rule of URL path map resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRule[] PathRule { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}