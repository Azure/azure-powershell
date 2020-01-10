namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Defines web application firewall policy properties</summary>
    public partial class WebApplicationFirewallPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="ApplicationGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] _applicationGateway;

        /// <summary>A collection of references to application gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get => this._applicationGateway; }

        /// <summary>Backing field for <see cref="CustomRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] _customRule;

        /// <summary>Describes custom rules inside the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get => this._customRule; set => this._customRule = value; }

        /// <summary>Internal Acessors for ApplicationGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal.ApplicationGateway { get => this._applicationGateway; set { {_applicationGateway = value;} } }

        /// <summary>Internal Acessors for PolicySetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal.PolicySetting { get => (this._policySetting = this._policySetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PolicySettings()); set { {_policySetting = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal.ResourceState { get => this._resourceState; set { {_resourceState = value;} } }

        /// <summary>Backing field for <see cref="PolicySetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings _policySetting;

        /// <summary>Describes policySettings for policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings PolicySetting { get => (this._policySetting = this._policySetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PolicySettings()); set => this._policySetting = value; }

        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettingsInternal)PolicySetting).EnabledState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettingsInternal)PolicySetting).EnabledState = value; }

        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettingsInternal)PolicySetting).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettingsInternal)PolicySetting).Mode = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? _resourceState;

        /// <summary>Resource status of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get => this._resourceState; }

        /// <summary>
        /// Creates an new <see cref="WebApplicationFirewallPolicyPropertiesFormat" /> instance.
        /// </summary>
        public WebApplicationFirewallPolicyPropertiesFormat()
        {

        }
    }
    /// Defines web application firewall policy properties
    public partial interface IWebApplicationFirewallPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A collection of references to application gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to application gateways.",
        SerializedName = @"applicationGateways",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get;  }
        /// <summary>Describes custom rules inside the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes custom rules inside the policy",
        SerializedName = @"customRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get; set; }
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if the policy is in enabled state or disabled state",
        SerializedName = @"enabledState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if it is in detection mode  or prevention mode at policy level",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get; set; }
        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the WebApplicationFirewallPolicy.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Resource status of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource status of the policy.",
        SerializedName = @"resourceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get;  }

    }
    /// Defines web application firewall policy properties
    internal partial interface IWebApplicationFirewallPolicyPropertiesFormatInternal

    {
        /// <summary>A collection of references to application gateways.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get; set; }
        /// <summary>Describes custom rules inside the policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get; set; }
        /// <summary>Describes policySettings for policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings PolicySetting { get; set; }
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get; set; }
        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Resource status of the policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get; set; }

    }
}