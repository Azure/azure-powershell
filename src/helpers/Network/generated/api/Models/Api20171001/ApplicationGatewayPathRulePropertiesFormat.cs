namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of path rule of an application gateway.</summary>
    public partial class ApplicationGatewayPathRulePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRulePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRulePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _backendAddressPool;

        /// <summary>Backend address pool resource of URL path map path rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendAddressPool { get => (this._backendAddressPool = this._backendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._backendAddressPool = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)BackendAddressPool).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)BackendAddressPool).Id = value; }

        /// <summary>Backing field for <see cref="BackendHttpSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _backendHttpSetting;

        /// <summary>Backend http settings resource of URL path map path rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendHttpSetting { get => (this._backendHttpSetting = this._backendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._backendHttpSetting = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendHttpSettingId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)BackendHttpSetting).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)BackendHttpSetting).Id = value; }

        /// <summary>Internal Acessors for BackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRulePropertiesFormatInternal.BackendAddressPool { get => (this._backendAddressPool = this._backendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_backendAddressPool = value;} } }

        /// <summary>Internal Acessors for BackendHttpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRulePropertiesFormatInternal.BackendHttpSetting { get => (this._backendHttpSetting = this._backendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_backendHttpSetting = value;} } }

        /// <summary>Internal Acessors for RedirectConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPathRulePropertiesFormatInternal.RedirectConfiguration { get => (this._redirectConfiguration = this._redirectConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_redirectConfiguration = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string[] _path;

        /// <summary>Path rules of URL path map.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RedirectConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _redirectConfiguration;

        /// <summary>Redirect configuration resource of URL path map path rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource RedirectConfiguration { get => (this._redirectConfiguration = this._redirectConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._redirectConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RedirectConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)RedirectConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)RedirectConfiguration).Id = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayPathRulePropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayPathRulePropertiesFormat()
        {

        }
    }
    /// Properties of path rule of an application gateway.
    public partial interface IApplicationGatewayPathRulePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendAddressPoolId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendHttpSettingId { get; set; }
        /// <summary>Path rules of URL path map.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path rules of URL path map.",
        SerializedName = @"paths",
        PossibleTypes = new [] { typeof(string) })]
        string[] Path { get; set; }
        /// <summary>
        /// Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RedirectConfigurationId { get; set; }

    }
    /// Properties of path rule of an application gateway.
    internal partial interface IApplicationGatewayPathRulePropertiesFormatInternal

    {
        /// <summary>Backend address pool resource of URL path map path rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendAddressPoolId { get; set; }
        /// <summary>Backend http settings resource of URL path map path rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendHttpSetting { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendHttpSettingId { get; set; }
        /// <summary>Path rules of URL path map.</summary>
        string[] Path { get; set; }
        /// <summary>
        /// Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Redirect configuration resource of URL path map path rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource RedirectConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string RedirectConfigurationId { get; set; }

    }
}